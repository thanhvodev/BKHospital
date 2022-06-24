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
            LoginCommand = new Command(OnLoginClicked);
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
                Email = "";
                Password = "";
                //await Application.Current.MainPage.DisplayAlert("Alert", serializedcontnet, "OK");
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
            }
        }
    }
}
