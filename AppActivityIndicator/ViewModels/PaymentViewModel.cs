using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    [QueryProperty(nameof(FeeId), nameof(FeeId))]
    [QueryProperty(nameof(MedicalSheetId), nameof(MedicalSheetId))]
    [QueryProperty(nameof(HospitalizationId), nameof(HospitalizationId))]
    public class PaymentViewModel : BaseViewModel
    {
        private int feeId;
        public int FeeId
        {
            get
            {
                return feeId;
            }
            set
            {
                feeId = value;
                LoadFeeId(value);
            }
        }

        private string medicalSheetId;
        public string MedicalSheetId { get => medicalSheetId; set => _ = SetProperty(ref medicalSheetId, value); }

        private string hospitalizationId;
        public string HospitalizationId { get => hospitalizationId; set => _ = SetProperty(ref hospitalizationId, value); }

        public Command BackToPayFeeCommand { get; }

        private void LoadFeeId(int value)
        {

        }

        public PaymentViewModel()
        {
            Title = "Thông tin thanh toán";
            BackToPayFeeCommand = new Command(async () => { await Shell.Current.GoToAsync($"{nameof(PayFeePage)}"); });
        }
    }
}
