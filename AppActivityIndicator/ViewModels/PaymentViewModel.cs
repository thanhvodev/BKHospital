using AppActivityIndicator.Models;
using AppActivityIndicator.Views;
using Rg.Plugins.Popup.Services;
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

        private DateTime startTime;
        public DateTime StartTime { get => startTime; set => _ = SetProperty(ref startTime, value); }

        private DateTime endTime;
        public DateTime EndTime { get => endTime; set => _ = SetProperty(ref endTime, value); }

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


        public Command BackToPayFeeCommand { get; }
        public Command PayCommand { get; }

        private async void Pay()
        {
            try
            {
                LoadingModal l = new LoadingModal();
                await PopupNavigation.Instance.PushAsync(l, true);
                await Application.Current.MainPage.DisplayAlert("Thanh toán thành công", "Bạn đã thanh toán viện phí thành công", "OK");
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                await PopupNavigation.Instance.PopAsync();
            }
            catch (Exception ex)
            {

            }

        }

        private async void LoadFeeId(int value)
        {
            Fee fee = await App.SqlBD.GetFeeAsync(value);
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

        public PaymentViewModel()
        {
            Title = "Xác nhận thông tin thanh toán";
            BackToPayFeeCommand = new Command(async () => { await Shell.Current.GoToAsync($"{nameof(PayFeePage)}"); });
            PayCommand = new Command(Pay);
        }
    }
}
