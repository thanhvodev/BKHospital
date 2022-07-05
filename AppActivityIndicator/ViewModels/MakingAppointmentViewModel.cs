using AppActivityIndicator.Helper;
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
        private string doctorName;
        public string DoctorName
        {
            get => doctorName;
            set => _ = SetProperty(ref doctorName, value);
        }

        private SpecialtyE specialty;
        public SpecialtyE Specialty
        {
            get => specialty;
            set => _ = SetProperty(ref specialty, value);
        }

        private DateTime date;
        public DateTime Date
        {
            get => date;
            set => _ = SetProperty(ref date, value);
        }

        private string time;
        public string Time
        {
            get => time;
            set => _ = SetProperty(ref time, value);
        }



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
