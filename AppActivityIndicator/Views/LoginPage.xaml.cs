using AppActivityIndicator.ViewModels;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppActivityIndicator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private async void TapGestureRecognizer_Tapped_SignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        private async void TapGestureRecognizer_Tapped_Reset(object sender, EventArgs e)
        {
            string result = await DisplayPromptAsync("Email", "Nhập Email của bạn để đổi mật khẩu");
            Debug.WriteLine(result);
            FirebaseAuthProvider authProvider = new FirebaseAuthProvider(new FirebaseConfig(Constants.WebAPIkey));
            if (!string.IsNullOrEmpty(result))
            {
                try
                {
                    await authProvider.SendPasswordResetEmailAsync(result);
                    await DisplayAlert("Thành công", "Vào hộp thư của bạn để đổi mật khẩu", "OK");
                }
                catch (Exception)
                {
                    await DisplayAlert("Có lỗi xảy ra", "Kiểm tra lại Email mà bạn đã nhập", "OK");
                }
            }
        }
    }
}