using AppActivityIndicator.ViewModels;
using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
