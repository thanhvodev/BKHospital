using AppActivityIndicator.Helper;
using AppActivityIndicator.Models;
using AppActivityIndicator.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class ReSheduleViewModel : BaseViewModel
    {
        private string medicalSheetId;
        private string @for;
        private DateTime date;
        private string specialty;
        private bool isNotHaveSchedule;
        private bool isShowReSchedule;

        public bool IsNotHaveSchedule { get => isNotHaveSchedule; set => _ = SetProperty(ref isNotHaveSchedule, value); }
        public bool IsShowReSchedule { get => isShowReSchedule; set => _ = SetProperty(ref isShowReSchedule, value); }
        public string For { get => @for; set => _ = SetProperty(ref @for, value); }
        public DateTime Date { get => date; set => _ = SetProperty(ref date, value); }
        public string Specialty { get => specialty; set => SetProperty(ref specialty, value); }
        public string MedicalSheetId { get => medicalSheetId; set => _ = SetProperty(ref medicalSheetId, value); }
        public Command FindMedicalSheetCommand { get; }

        public ReSheduleViewModel ()
        {
            Title = "Lịch tái khám";
            IsNotHaveSchedule = false;
            IsShowReSchedule = false;
            FindMedicalSheetCommand = new Command (FindMedicalSheet, ValidateFind);
            PropertyChanged +=
                (_, __) => FindMedicalSheetCommand.ChangeCanExecute ();
        }

        private async void FindMedicalSheet ()
        {
            try
            {
                LoadingModal t = new LoadingModal ();
                await PopupNavigation.Instance.PushAsync (t, true);
                // Load Shedule
                await Fetch (MedicalSheetId);
                // End
                await PopupNavigation.Instance.PopAsync ();
                IsShowReSchedule = true;

            }
            catch (Exception)
            {
                await PopupNavigation.Instance.PopAsync();
                //await Application.Current.MainPage.DisplayAlert ("Oops", ToString(), "OK");
                IsNotHaveSchedule = true;
                IsShowReSchedule = false;
            }
        }

        private bool ValidateFind () => Regex.IsMatch (MedicalSheetId ?? "", Constants.MEDICAL_SHEET_ID_REGEX);

        private async Task Fetch(string mdId)
        {
            (Date, Specialty) = await App.SqlBD.GetReShedule(mdId);
        }

    }
}
