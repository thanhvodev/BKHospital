using AppActivityIndicator.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppActivityIndicator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReSchedulePage : ContentPage
    {
        public ReSchedulePage()
        {
            InitializeComponent();
            BindingContext = new ReSheduleViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                LoadingModal t = new LoadingModal();
                await PopupNavigation.Instance.PushAsync(t, true);
                Thread.Sleep(200);
                await PopupNavigation.Instance.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oops", ex.Message, "OK");
            }
        }
    }
}