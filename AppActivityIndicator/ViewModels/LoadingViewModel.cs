using AppActivityIndicator.Helper;
using AppActivityIndicator.Views;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    [QueryProperty(nameof(Email_Password), nameof(Email_Password))]
    public class LoadingViewModel : BaseViewModel
    {
        #region Field and Property
        private string email_password;
        public string Email_Password
        {
            get => email_password;
            set
            {
                email_password = value;
                LoadEmailPassword(value);
            }
        }

        #endregion

        #region Method
        private async void LoadEmailPassword(string em)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.WebAPIkey));
            try
            {
                string[] em_pa = em.Split(',');
                FirebaseAuthLink auth = await authProvider.SignInWithEmailAndPasswordAsync(em_pa[0], em_pa[1]);
                FirebaseAuthLink content = await auth.GetFreshAuthAsync();
                string serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                Preferences.Set("UserEmail", content.User.Email);
                await App.SqlBD.FetchDataToLocal();
                //await Application.Current.MainPage.DisplayAlert("Alert", serializedcontnet, "OK");
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }
        #endregion
    }
}
