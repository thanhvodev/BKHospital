using AppActivityIndicator.Helper;
using AppActivityIndicator.Views;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        private string email;
        public string Email
        {
            get => email;
            set => _ = SetProperty(ref email, value);
        }
        private string password;
        public string Password
        {
            get => password;
            set => _ = SetProperty(ref password, value);
        }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClickedLoading);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.WebAPIkey));
            try
            {
                FirebaseAuthLink auth = await authProvider.SignInWithEmailAndPasswordAsync(Email, Password);
                FirebaseAuthLink content = await auth.GetFreshAuthAsync();
                string serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                Preferences.Set(Constants.USER_EMAIL_STRING, content.User.Email);
                Email = "";
                Password = "";
                await App.SqlBD.FetchDataToLocal();
                //await Application.Current.MainPage.DisplayAlert("Alert", serializedcontnet, "OK");
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private async void OnLoginClickedLoading(object obj)
        {
            try
            {
                string email_password = Email + "," + Password;
                await Shell.Current.GoToAsync($"{nameof(LoadingPage)}?{nameof(LoadingViewModel.Email_Password)}={email_password}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
        }
    }
}
