using AppActivityIndicator.ViewModels;
using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(MakingAppointmentPage), typeof(MakingAppointmentPage));
            Routing.RegisterRoute(nameof(MASuccessPage), typeof(MASuccessPage));
            Routing.RegisterRoute(nameof(MedicalSheetsPage), typeof(MedicalSheetsPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            await Current.GoToAsync("//LoginPage");
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            //hide flyout
            Current.FlyoutIsPresented = false;
            await Navigation.PushAsync(new ItemsPage());
        }

        private async void ProfileItem_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            //await Navigation.PushAsync(new ProfilePage());
            string fromId = "HomePage";
            await Shell.Current.GoToAsync($"{nameof(ProfilePage)}?{nameof(ProfileViewModel.FromId)}={fromId}");
        }

        private async void Logout(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            await App.SqlBD.ClearLocal();
            await Current.GoToAsync("//LoginPage");
        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync($"{nameof(MedicalSheetsPage)}");
        }
    }
}
