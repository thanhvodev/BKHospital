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
            Specialty.IsEnabled = false;
            Doctor.IsEnabled = false;
            Time.IsEnabled = false;
            Order.IsEnabled = false;
            datePicker.MinimumDate = DateTime.Now.AddDays(1);
            datePicker.MaximumDate = DateTime.Now.AddDays(7);
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new ProfilePage());
            await Shell.Current.GoToAsync($"{nameof(ProfilePage)}");
        }

        private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            Specialty.IsEnabled = true;
            List<Specialty> specialties = await App.SqlBD.GetSpecialties();
            List<string> src = specialties.Select(s => s.Name).ToList();
            Specialty.ItemsSource = src;
        }

        private async void Specialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            Doctor.IsEnabled = true;
            //await Application.Current.MainPage.DisplayAlert("Thành công", $"{Specialty.SelectedIndex}", "OK");
            List<Doctor> doctors = await App.SqlBD.GetDoctors(Specialty.SelectedIndex);
            List<string> src = doctors.Select(d => d.Name).ToList();
            Doctor.ItemsSource = src;
        }

        private async void Doctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Time.IsEnabled = true;
            Time.ItemsSource = await App.SqlBD.GetTimes(Doctor.SelectedItem.ToString());
        }

        private void Time_SelectedIndexChanged(object sender, EventArgs e)
        {
            Order.IsEnabled = true;
        }
    }
}