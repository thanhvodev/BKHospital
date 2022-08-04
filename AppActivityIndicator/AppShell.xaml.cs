using AppActivityIndicator.ViewModels;
using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(MakingAppointmentPage), typeof(MakingAppointmentPage));
            Routing.RegisterRoute(nameof(MASuccessPage), typeof(MASuccessPage));
            Routing.RegisterRoute(nameof(MedicalSheetsPage), typeof(MedicalSheetsPage));
            Routing.RegisterRoute(nameof(MedicalSheetDetailPage), typeof(MedicalSheetDetailPage));
            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CCCDPage), typeof(CCCDPage));
            Routing.RegisterRoute(nameof(ReSchedulePage), typeof(ReSchedulePage));
            Routing.RegisterRoute(nameof(PayFeePage), typeof(PayFeePage));
            Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
            Routing.RegisterRoute(nameof(PaymentsPage), typeof(PaymentsPage));
            Routing.RegisterRoute(nameof(PaymentDetailPage), typeof(PaymentDetailPage));
            Routing.RegisterRoute(nameof(UserManualPage), typeof(UserManualPage));
            Routing.RegisterRoute(nameof(FeedBackPage), typeof(FeedBackPage));
            Routing.RegisterRoute(nameof(MedicalExaminationProcessPage), typeof(MedicalExaminationProcessPage));
            Routing.RegisterRoute(nameof(TermsOfServicePage), typeof(TermsOfServicePage));
            Routing.RegisterRoute(nameof(SecurityPolicyPage), typeof(SecurityPolicyPage));
            Routing.RegisterRoute(nameof(TermsOfUsePage), typeof(TermsOfUsePage));
            Routing.RegisterRoute(nameof(CommonQuestionsPage), typeof(CommonQuestionsPage));
            Routing.RegisterRoute(nameof(IntroductionPage), typeof(IntroductionPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            await Current.GoToAsync("//LoginPage");
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            //hide flyout
            Current.FlyoutIsPresented = false;
            await Navigation.PushAsync(new ItemsPage());
        }

        private async void ProfileItem_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            //await Navigation.PushAsync(new ProfilePage());
            string fromId = "HomePage";
            await Current.GoToAsync($"{nameof(ProfilePage)}?{nameof(ProfileViewModel.FromId)}={fromId}");
        }

        private async void Logout(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            Preferences.Remove("MyFirebaseRefreshToken");
            await App.SqlBD.ClearLocal();
            await Current.GoToAsync($"{nameof(LoginPage)}");
        }

        private async void MenuItem_Clicked_1(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(MedicalSheetsPage)}");
        }

        private async void Fingerprint_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(CCCDPage)}");
        }

        private async void Bill_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(PaymentsPage)}");
        }

        private async void UserManual_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(UserManualPage)}");
        }

        private async void FeedBack_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(FeedBackPage)}");
        }

        private async void MedicalExaminationProcess_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(MedicalExaminationProcessPage)}");
        }

        private async void TermsOfService_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(TermsOfServicePage)}");
        }
        private async void SecurityPolicy_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(SecurityPolicyPage)}");
        }

        private async void TermsOfUse_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(TermsOfUsePage)}");
        }

        private async void CommonQuestions_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(CommonQuestionsPage)}");
        }

        private async void Introduction_Button_Clicked(object sender, EventArgs e)
        {
            Current.FlyoutIsPresented = false;
            await Current.GoToAsync($"{nameof(IntroductionPage)}");
        }

    }
}
