using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class MakingAppointmentViewModel : BaseViewModel
    {

        public MakingAppointmentViewModel()
        {
            CallSupportCommand = new Command(() => PhoneDialer.Open("1945724833"));
            BackBehavior = new Command(async () =>
            {
                try
                {
                    await Shell.Current.GoToAsync("//AboutPage");
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Alert", "Broken", "OK");
                }
            });

        }

        public ICommand CallSupportCommand { get; }
        public ICommand BackBehavior { get; }

    }
}
