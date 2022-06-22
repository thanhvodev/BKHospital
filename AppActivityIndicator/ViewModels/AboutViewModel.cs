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
            Title = "HCMUT";
            OpenWebCommand = new Command(async () =>
            {
                if (Device.RuntimePlatform == Device.iOS)
                {
                    // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    await Launcher.OpenAsync("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA");
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    // open the maps app directly
                    await Launcher.OpenAsync("geo:0,0?q=HCMC+National+University+Dormitary+Zone+A");
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    await Launcher.OpenAsync("bingmaps:?where=394 Pacific Ave San Francisco CA");
                }
            });
            CallSupportCommand = new Command(() => PhoneDialer.Open("1945724833"));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand CallSupportCommand { get; }
    }
}