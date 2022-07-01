using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppActivityIndicator.Models;
using AppActivityIndicator.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppActivityIndicator.Services;
using System.Diagnostics;
using System.Threading;

namespace AppActivityIndicator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private readonly API api;
        private bool isLoadFirstTime;
        public ProfilePage()
        {
            InitializeComponent();
            isLoadFirstTime = true;
            api = API.GetInstance();
            BindingContext = new ProfileViewModel();
            Sex.ItemsSource = new string[]
            {
                "Nam", "Nữ"
            };
            Sex.SetBinding(Picker.SelectedItemProperty, new Binding("Sex", source: BindingContext));
            GetCountrys();
            GetProvinces();
        }

        private async void GetCountrys()
        {
            try
            {
                List<Country> repositories = await api.GetCountrysAsync($"{Constants.CountryAPIEndpoint}/v2/all/");
                List<string> src = new List<string>();
                foreach (Country country in repositories)
                {
                    src.Add(country.Name);
                }
                Country.ItemsSource = src;
                Country.SetBinding(Picker.SelectedItemProperty, new Binding("Nation", source: BindingContext));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        //set up when first load
        private async void GetProvinces()
        {
            try
            {
                List<Province> repositories = await api.GetProvincesAsync($"{Constants.ProvinceAPIEndpoint}/api/p/");
                Province.ItemsSource = repositories;
                Province.SetBinding(Picker.SelectedIndexProperty, new Binding("ProvinceInx", source: BindingContext));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (isLoadFirstTime)
                {
                    List<District> repositories = await api.GetDistrictsAsync($"{Constants.ProvinceAPIEndpoint}/api/p/{(Province.SelectedItem as Province).Code}/?depth=2");
                    District.ItemsSource = repositories;
                    if (District.SelectedIndex == -1)
                    {
                        District.SelectedIndex = (BindingContext as ProfileViewModel).DistrictInx;
                        List<Ward> wrepositories = await api.GetWardsAsync($"{Constants.ProvinceAPIEndpoint}/api/d/{(District.SelectedItem as District).Code}/?depth=2");
                        Ward.ItemsSource = wrepositories;
                        if (Ward.SelectedIndex == -1)
                        {
                            Ward.SelectedIndex = (BindingContext as ProfileViewModel).WardInx;

                        }
                        //await DisplayAlert("Nani", "vcv", "OK");
                    }

                }
                else
                {
                    List<District> repositories = await api.GetDistrictsAsync($"{Constants.ProvinceAPIEndpoint}/api/p/{(Province.SelectedItem as Province).Code}/?depth=2");
                    District.ItemsSource = repositories;
                    District.SelectedIndex = 0;
                }

            }
            catch (Exception)
            {
                //await DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private async void District_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isLoadFirstTime)
                {
                    List<Ward> repositories = await api.GetWardsAsync($"{Constants.ProvinceAPIEndpoint}/api/d/{(District.SelectedItem as District).Code}/?depth=2");
                    Ward.ItemsSource = repositories;
                    Ward.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                //await DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private void Ward_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoadFirstTime)
            {
                isLoadFirstTime = false;
            }
            else
            {
                Ward.SetBinding(Picker.SelectedIndexProperty, new Binding("WardInx", source: BindingContext));
                District.SetBinding(Picker.SelectedIndexProperty, new Binding("DistrictInx", source: BindingContext));
            }
        }
    }
}