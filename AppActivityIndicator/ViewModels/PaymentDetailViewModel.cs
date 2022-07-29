using AppActivityIndicator.Models;
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
            get => billId;
            set
            {
                _ = SetProperty(ref billId, value);
                LoadBillId(value);
            }
        }

        private string medicalSheetId;
        public string MedicalSheetId
        {
            get { return medicalSheetId; }
            set
            {
                _ = SetProperty(ref medicalSheetId, value);
            }
        }

        private string hospitalizationId;
        public string HospitalizationId
        {
            get { return hospitalizationId; }
            set
            {
                _ = SetProperty(ref hospitalizationId, value);
            }
        }

        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                _ = SetProperty(ref startTime, value);
            }
        }

        private DateTime endTime;
        public DateTime EndTime
        {
            get { return endTime; }
            set
            {
                _ = SetProperty(ref endTime, value);
            }
        }

        private DateTime datePayed;
        public DateTime DatePayed
        {
            get { return datePayed; }
            set
            {
                _ = SetProperty(ref datePayed, value);
            }
        }

        private long phiKhamBenh;
        public long PhiKhamBenh { get => phiKhamBenh; set => _ = SetProperty(ref phiKhamBenh, value); }


        private long phiPhauThuat;
        public long PhiPhauThuat { get => phiPhauThuat; set => _ = SetProperty(ref phiPhauThuat, value); }


        private long phiThuoc;
        public long PhiThuoc { get => phiThuoc; set => _ = SetProperty(ref phiThuoc, value); }


        private long phiAnUong;
        public long PhiAnUong { get => phiAnUong; set => _ = SetProperty(ref phiAnUong, value); }


        private long phiDieuDuong;
        public long PhiDieuDuong { get => phiDieuDuong; set => _ = SetProperty(ref phiDieuDuong, value); }


        private long phiONoiTru;
        public long PhiONoiTru { get => phiONoiTru; set => _ = SetProperty(ref phiONoiTru, value); }

        private long total;
        public long Total { get => total; set => _ = SetProperty(ref total, value); }

        public Command BackCommand { get; }
        public PaymentDetailViewModel()
        {
            Title = BillId;
            BackCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(PaymentsPage)));
        }

        private async void LoadBillId(string pBillId)
        {
            try
            {
                Bill bill = await App.SqlBD.GetBillAsync(pBillId);
                Console.WriteLine(bill.ToString());
                PayFee payFee = await App.SqlBD.GetPayFeeAsync(bill.PayFeeId);
                Fee fee = await App.SqlBD.GetFeeAsync(payFee.FeeId);
                DatePayed = bill.DatePayed;
                MedicalSheetId = payFee.ProfileNumber;
                HospitalizationId = payFee.HospitalizationNumber;
                StartTime = fee.StartTime;
                EndTime = fee.EndTime;
                PhiAnUong = fee.PhiAnUong;
                PhiONoiTru = fee.PhiONoiTru;
                PhiDieuDuong = fee.PhiDieuDuong;
                PhiKhamBenh = fee.PhiKhamBenh;
                PhiPhauThuat = fee.PhiPhauThuat;
                PhiThuoc = fee.PhiThuoc;
                Total = PhiAnUong + PhiONoiTru + PhiDieuDuong + PhiKhamBenh + PhiPhauThuat + PhiThuoc;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
            }

        }
    }
}
