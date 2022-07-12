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
            Routing.RegisterRoute(nameof(MedicalSheetDetailPage), typeof(MedicalSheetDetailPage));
            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(Notifications), typeof(Notifications));
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
            Current.FlyoutIsPresented = false;
            Preferences.Remove("MyFirebaseRefreshToken");
            await App.SqlBD.ClearLocal();
            await Shell.Current.GoToAsync($"{nameof(LoginPage)}");
        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync($"{nameof(MedicalSheetsPage)}");
        }

        private async void Notification_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync($"{nameof(Notifications)}");

        }
    }
}
