using AppActivityIndicator.Models;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    internal class SignUpViewModel : BaseViewModel
    {
        public Command SignUpCommand { get; }
        private string email;
        private string password;

        public SignUpViewModel()
        {
            SignUpCommand = new Command(OnSignUpClicked);
        }

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
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Thất bại", ex.Message, "OK");
            }
        }

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
    }
}
