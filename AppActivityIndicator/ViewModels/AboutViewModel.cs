using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            CallSupportCommand = new Command(() => PhoneDialer.Open("1945724833"));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand CallSupportCommand { get; }
    }
}