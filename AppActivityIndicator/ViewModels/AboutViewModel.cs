using AppActivityIndicator.Helper;
using AppActivityIndicator.Models;
using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        #region Field and Property
        public ICommand OpenWebCommand { get; }
        public ICommand CallSupportCommand { get; }
        public ICommand GoToMSsPage { get; }
        public ICommand GoToPayFeePage { get; }
        public ICommand GoToReShedule { get; }
        public List<ThumbnailImage> Images { get; set; }

        #endregion

        public AboutViewModel()
        {
            Title = "HCMUT";
            Images = new List<ThumbnailImage>
            {
                new ThumbnailImage() { ImageURL = "doctors.png" },
                new ThumbnailImage() { ImageURL = "doctor_surgery.jpg" }
            };
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
                    await Launcher.OpenAsync("geo:0,0?q=" + Constants.HOSPITAL_ADDRESS);
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    await Launcher.OpenAsync("bingmaps:?where=394 Pacific Ave San Francisco CA");
                }
            });
            CallSupportCommand = new Command(() => PhoneDialer.Open(Constants.SUPPORT_PHONE_NUMBER));
            GoToMSsPage = new Command(async () => await Shell.Current.GoToAsync($"{nameof(MedicalSheetsPage)}"));
            GoToReShedule = new Command(async () => await Shell.Current.GoToAsync($"{nameof(ReSchedulePage)}"));
            GoToPayFeePage = new Command(async () => await Shell.Current.GoToAsync($"{nameof(PayFeePage)}"));
        }

    }
}