using AppActivityIndicator.Helper;
using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        private int specialty;
        public int Specialty
        { 
            get => specialty;
            set => _ = SetProperty(ref specialty, value);
        }

        private string specialtyName;
        public string SpecialtyName
        {
            get => specialtyName;
            set => _ = SetProperty(ref specialtyName, value);
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
            CallSupportCommand = new Command(() => PhoneDialer.Open(Constants.SUPPORT_PHONE_NUMBER));
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
            MACommand = new Command(MA);

        }

        private async void MA()
        {
            Random rnd = new Random();
            int num = rnd.Next();
            string mId = $"AS-{num}";
            await App.SqlBD.InsertMedicalSheetAsync(mId, DoctorName, Time, Date, Specialty, Preferences.Get("UserEmail", ""), SpecialtyName);
            await Shell.Current.GoToAsync($"{nameof(MASuccessPage)}?{nameof(MASuccessViewModel.MId)}={mId}");
        }

        public ICommand CallSupportCommand { get; }
        public ICommand BackBehavior { get; }
        public ICommand MACommand { get; }
    }
}
