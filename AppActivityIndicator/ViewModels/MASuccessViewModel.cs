using AppActivityIndicator.Models;
using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    [QueryProperty(nameof(MId), nameof(MId))]
    public class MASuccessViewModel : BaseViewModel
    {
        private string mId;
        public string MId
        {
            get => mId;
            set => _ = SetProperty(ref mId, value);
        }

        private async void Fetch()
        {
            try
            {
                await Application.Current.MainPage.DisplayAlert("Thành công", $"Bạn đã đặt khám thành công, vui lòng kiểm tra thông tin", "OK");
                var item = await App.SqlBD.GetMedicalSheet(MId);
                DoctorName = item.DoctorName;
                switch(item.SpecialtyId)
                {
                    case 0:
                        Specialty = "Chuyên khoa Tai, mũi, họng";
                        break;
                    case 1:
                        Specialty = "Chuyên khoa Não và thần kinh";
                        break;
                    case 2:
                        Specialty = "Chuyên khoa Ung thư";
                        break;
                    case 3:
                        Specialty = "Chuyên khoa Nội tổng quát";
                        break;
                    case 4:
                        Specialty = "Chuyên khoa Tiết niệu";
                        break;
                    default:
                        break;
                }
                Date = item.Date.ToLongDateString();
                Time = item.Time;
                STT = item.STT;
                RoomName = item.RoomName;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private string doctorName;
        public string DoctorName
        {
            get => doctorName;
            set => _ = SetProperty(ref doctorName, value);
        }

        private string specialty;
        public string Specialty
        {
            get => specialty;
            set => _ = SetProperty(ref specialty, value);
        }

        private string date;
        public string Date
        {
            get => date;
            set => _ = SetProperty(ref date, value);
        }

        private int stt;
        public int STT
        {
            get => stt;
            set => _ = SetProperty(ref stt, value);
        }

        private string roomName;
        public string RoomName
        {
            get => roomName;
            set => _ = SetProperty(ref roomName, value);
        }

        private string time;
        public string Time
        {
            get => time;
            set => _ = SetProperty(ref time, value);
        }

        public MASuccessViewModel()
        {
            Fetch();
            BackToHomeCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//AboutPage");
            });
        }

        public ICommand BackToHomeCommand { get; }
    }
}
