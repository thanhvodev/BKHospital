using AppActivityIndicator.Models;
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
        public Command BackToPayFeeCommand { get; }

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
        }

        public PaymentViewModel()
        {
            Title = "Xác nhận thông tin";
            BackToPayFeeCommand = new Command(async () => { await Shell.Current.GoToAsync($"{nameof(PayFeePage)}"); });
        }
    }
}
