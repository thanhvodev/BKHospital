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
    public class ReSheduleViewModel : BaseViewModel
    {
        private string medicalSheetId;

        public string MedicalSheetId
        {
            get => medicalSheetId;
            set => _ = SetProperty(ref medicalSheetId, value);
        }
        public Command FindMedicalSheetCommand { get; }

        public ReSheduleViewModel ()
        {
            Title = "Lịch tái khám";
            FindMedicalSheetCommand = new Command(FindMedicalSheet, ValidateFind);
            PropertyChanged +=
                (_, __) => FindMedicalSheetCommand.ChangeCanExecute();
        }

        private async void FindMedicalSheet ()
        {
            try
            {
                LoadingModal t = new LoadingModal();
                await PopupNavigation.Instance.PushAsync(t, true);
                Thread.Sleep(200);
                await PopupNavigation.Instance.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
            }
        }

        private bool ValidateFind() => Regex.IsMatch(MedicalSheetId ?? "", Constants.MEDICAL_SHEET_ID_REGEX);
    }
}
