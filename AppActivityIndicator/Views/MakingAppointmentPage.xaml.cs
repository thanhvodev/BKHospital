using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppActivityIndicator.Helper;
using AppActivityIndicator.Models;
using AppActivityIndicator.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppActivityIndicator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MakingAppointmentPage : ContentPage
    {
        public MakingAppointmentPage()
        {
            InitializeComponent();
            Time.IsEnabled = false;
            Order.IsEnabled = false;
            datePicker.MinimumDate = DateTime.Now;
            datePicker.MaximumDate = DateTime.Now.AddDays(7);
            Specialty.IsEnabled = false;
            Doctor.IsEnabled = false;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ProfilePage());
            await Shell.Current.GoToAsync($"{nameof(ProfilePage)}");
        }

        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (datePicker.Date.DayOfWeek == DayOfWeek.Saturday || datePicker.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                await Application.Current.MainPage.DisplayAlert("Thất bại", $"Không thể đăng ký khám vào T7, CN", "Chọn ngày khác");
                return;
            }

            Specialty.IsEnabled = true;
            List<Specialty> specialties = await App.SqlBD.GetSpecialties();
            List<string> src = specialties.Select(s => s.Name).ToList();
            Specialty.ItemsSource = src;
        }

        private async void Specialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Doctor.IsEnabled = true;
            List<Doctor> doctors = await App.SqlBD.GetDoctors(Specialty.SelectedIndex);
            List<string> src = doctors.Select(d => d.Name).ToList();
            Doctor.ItemsSource = src;
        }

        private async void Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Time.IsEnabled = true;
                Time.ItemsSource = await App.SqlBD.GetTimes(Doctor.SelectedItem.ToString());
            }
            catch (Exception)
            {
                Time.SelectedIndex = -1;
                //await DisplayAlert(nameof(MakingAppointmentPage), ex.Message, "OK");
            }
        }

        private void Time_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order.IsEnabled = true;
        }
    }
}