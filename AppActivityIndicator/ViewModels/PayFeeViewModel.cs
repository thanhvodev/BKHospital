using AppActivityIndicator.Helper;
using AppActivityIndicator.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class PayFeeViewModel : BaseViewModel
    {
        private string medicalSheetId;
        public string MedicalSheetId { get => medicalSheetId; set => _ = SetProperty(ref medicalSheetId, value); }

        private string hospitalizationId;
        public string HospitalizationId { get => hospitalizationId; set => _ = SetProperty(ref hospitalizationId, value); }
        public Command GoToPaymentInfoPageCommand { get; }



        public PayFeeViewModel()
        {
            Title = "Thanh toán viện phí";
            GoToPaymentInfoPageCommand = new Command(GoToPaymentInfoPage, ValidateFind);
            PropertyChanged +=
                    (_, __) => GoToPaymentInfoPageCommand.ChangeCanExecute();
        }

        private async void GoToPaymentInfoPage()
        {
            try
            {
                LoadingModal t = new LoadingModal();
                await PopupNavigation.Instance.PushAsync(t, true);
                // Load Shedule
                Thread.Sleep(2000);
                // End
                await PopupNavigation.Instance.PopAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private bool ValidateFind() 
        {
            return Regex.IsMatch(MedicalSheetId ?? "", Constants.MEDICAL_SHEET_ID_REGEX) && Regex.IsMatch(HospitalizationId ?? "", Constants.HOSPITALIZATION_ID_REGEX);
        }    
    }
}
