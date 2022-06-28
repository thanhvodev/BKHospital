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
                List<string> src = new List<string>();
                foreach (var repo in repositories)
                {
                    src.Add(repo.Name);
                }
                Province.ItemsSource = src;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private async void Province_Focused(object sender, FocusEventArgs e)
        {
            await api.GetDistrictsAsync("https://provinces.open-api.vn/api/p/1?depth=2");
        }
    }
}