using AppActivityIndicator.Models;
using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    [QueryProperty(nameof(MId), nameof(MId))]
    public class MedicalSheetDetailViewModel : BaseViewModel
    {
        #region Field and Property
        private string mId;
        public string MId
        {
            get => mId;
            set
            {
                LoadMId(value);
                _ = SetProperty(ref mId, value);
            }
        }

        private string state;
        public string State
        {
            get => state;
            set
            {
                _ = SetProperty(ref state, value);
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

        public ICommand BackToHomeCommand { get; }
        #endregion


        #region Method

        public MedicalSheetDetailViewModel()
        {
            BackToHomeCommand = new Command(async () =>
            {
                try
                {
                    await Shell.Current.GoToAsync($"{nameof(MedicalSheetsPage)}");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
                }
            });
        }
        private async void LoadMId(string msId)
        {
            try
            {
                MedicalSheet m = await App.SqlBD.GetMedicalSheet(msId);
                DoctorName = m.DoctorName;
                STT = m.STT;
                RoomName = m.RoomName;
                Specialty = m.SpecialtyName;
                Time = m.Time;
                Date = m.Date.ToString("dd/MM/yyyy");
                State = m.State;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
            }
        }
        #endregion
    }
}
