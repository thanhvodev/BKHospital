using AppActivityIndicator.Helper;
using AppActivityIndicator.Models;
using AppActivityIndicator.Services;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    internal class SignUpViewModel : BaseViewModel
    {
        private string email;
        private string password;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public SignUpViewModel()
        {
            SignUpCommand = new Command(OnSignUpClicked);
        }

        public Command SignUpCommand { get; }

        private async void OnSignUpClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            try
            {
                FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.WebAPIkey));
                FirebaseAuthLink auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                string gettoken = auth.FirebaseToken;
                await Application.Current.MainPage.DisplayAlert("Thành công", $"Bạn đã đăng ký tài khoản với Email {Email} thành công", "Quay lại trang đăng nhập");
                await Shell.Current.GoToAsync("//LoginPage");
                await App.SqlBD.AddUser(email);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Thất bại", ex.Message, "OK");
            }
        }
    }
}
