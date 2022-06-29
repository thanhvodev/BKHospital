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
                Country.SetBinding(Picker.SelectedItemProperty, new Binding("Country", source: BindingContext));
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
                Province.SelectedIndex = (BindingContext as ProfileViewModel).ProvinceInx;
                Debug.WriteLine(Province.SelectedIndex);

                //List<District> drepositories = await api.GetDistrictsAsync($"{Constants.ProvinceAPIEndpoint}/api/p/{(Province.SelectedItem as Province).Code}/?depth=2");
                //District.ItemsSource = drepositories;
                //District.SelectedIndex = (BindingContext as ProfileViewModel).DistrictInx;
                //Debug.WriteLine(District.SelectedIndex);

                //List<Ward> wrepositories = await api.GetWardsAsync($"{Constants.ProvinceAPIEndpoint}/api/d/{(District.SelectedItem as District).Code}/?depth=2");
                //Ward.ItemsSource = wrepositories;
                //Ward.SelectedIndex = (BindingContext as ProfileViewModel).WardInx;
            }
            catch (Exception)
            {
                //await DisplayAlert("Alert", ex.Message, "OK");
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
                    District.SelectedIndex = (BindingContext as ProfileViewModel).DistrictInx;
                }
                else {
                    List<District> repositories = await api.GetDistrictsAsync($"{Constants.ProvinceAPIEndpoint}/api/p/{(Province.SelectedItem as Province).Code}/?depth=2");
                    District.ItemsSource = repositories;
                    District.SelectedIndex = 0;
                    (BindingContext as ProfileViewModel).Province = (Province.SelectedItem as Province).Name;
                    (BindingContext as ProfileViewModel).ProvinceInx = Province.SelectedIndex;
                }

            }
            catch (Exception ex)
            {
                //await DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private async void District_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (isLoadFirstTime)
                {
                    List<Ward> repositories = await api.GetWardsAsync($"{Constants.ProvinceAPIEndpoint}/api/d/{(District.SelectedItem as District).Code}/?depth=2");
                    Ward.ItemsSource = repositories;
                    Ward.SelectedIndex = (BindingContext as ProfileViewModel).WardInx;
                }
                else
                {
                    List<Ward> repositories = await api.GetWardsAsync($"{Constants.ProvinceAPIEndpoint}/api/d/{(District.SelectedItem as District).Code}/?depth=2");
                    Ward.ItemsSource = repositories;
                    Ward.SelectedIndex = 0;
                    (BindingContext as ProfileViewModel).District = (District.SelectedItem as District).Name;
                    (BindingContext as ProfileViewModel).DistrictInx = District.SelectedIndex;
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
                //(BindingContext as ProfileViewModel).Ward = (Ward.SelectedItem as Ward).Name;
                (BindingContext as ProfileViewModel).WardInx = Ward.SelectedIndex;
            }
        }
    }
}