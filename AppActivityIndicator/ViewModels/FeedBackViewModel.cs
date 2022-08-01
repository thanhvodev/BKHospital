using AppActivityIndicator.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class FeedBackViewModel : BaseViewModel
    {
        private string feedBack;
        public string FeedBack { get => feedBack; set => _ = SetProperty(ref feedBack, value); }
        public Command SendFeedBackCommand { get; }


        public FeedBackViewModel()
        {
            Title = "Góp ý";
            SendFeedBackCommand = new Command(SendFeedBackAsync, ValidationSendFeedBackCommand);
            PropertyChanged +=
            (_, __) => SendFeedBackCommand.ChangeCanExecute();
        }

        public bool ValidationSendFeedBackCommand(object args)
        {
            return !string.IsNullOrEmpty(FeedBack);
        }
        public async void SendFeedBackAsync(object obj)
        {
            try
            {
                LoadingModal t = new LoadingModal();
                await PopupNavigation.Instance.PushAsync(t, true);
                App.API.SendEmail(FeedBack);
                FeedBack = "";
                await Application.Current.MainPage.DisplayAlert("Thành công", "Bạn đã gửi góp ý thành công!", "OK");
                await PopupNavigation.Instance.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(Title, ex.Message, "OK");
            }
        }
    }
}
