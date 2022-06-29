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
        public ProfilePage()
        {
            InitializeComponent();
            api = API.GetInstance();
            BindingContext = new ProfileViewModel();
            Sex.ItemsSource = new string[]
            {
                "Nam", "Nữ"
            };

            Sex.SetBinding(Picker.SelectedItemProperty, new Binding("Sex", source: BindingContext));
            GetProvinces();
        }

        private async void GetProvinces()
        {
            try
            {
                List<Province> repositories = await api.GetProvincesAsync($"{Constants.ProvinceAPIEndpoint}/api/p/");
                Province.ItemsSource = repositories;
                Province.ItemDisplayBinding = new Binding("Name");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private async void Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<District> repositories = await api.GetDistrictsAsync($"{Constants.ProvinceAPIEndpoint}/api/p/{(Province.SelectedItem as Province).Code}/?depth=2");
                District.ItemsSource = repositories;
                District.ItemDisplayBinding = new Binding("Name");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private async void District_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Ward> repositories = await api.GetWardsAsync($"{Constants.ProvinceAPIEndpoint}/api/d/{(District.SelectedItem as District).Code}/?depth=2");
                Ward.ItemsSource = repositories;
                Ward.ItemDisplayBinding = new Binding("Name");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}