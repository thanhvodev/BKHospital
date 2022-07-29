using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    [QueryProperty(nameof(BillId), nameof(BillId))]
    public class PaymentDetailViewModel : BaseViewModel
    {
        private string billId;
        public string BillId
        {
            get { return billId; }
            set => _ = SetProperty(ref billId, value);
        }

        public Command BackCommand { get; }
        public PaymentDetailViewModel()
        {
            Title = BillId;
            BackCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(PaymentsPage)));
        }

        private async void LoadBillId()
        {

        }
    }
}
