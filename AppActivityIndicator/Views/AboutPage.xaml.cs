using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppActivityIndicator.ViewModels;
using AppActivityIndicator.Helper;

namespace AppActivityIndicator.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            GetProfileInformationAndRefreshToken();
        }

        private async void GetProfileInformationAndRefreshToken()
        {
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.WebAPIkey));
            try
            {
                //This is the saved firebaseauthentication that was saved during the time of login
                FirebaseAuth savedfirebaseauth = JsonConvert.DeserializeObject<FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //Here we are Refreshing the token
                FirebaseAuthLink RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //Now lets grab user information
                //MyUserName.Text = RefreshedContent.User.Email;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await Application.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }
        }

        private async void MakeAppoint_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MakingAppointmentPage());
        }
    }
}