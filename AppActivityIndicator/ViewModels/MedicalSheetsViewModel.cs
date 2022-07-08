using AppActivityIndicator.Models;
using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class MedicalSheetsViewModel : BaseViewModel
    {
        #region field and property

        private string name_id;
        public string Name_Id
        {
            get => name_id;
            set => _ = SetProperty(ref name_id, value);
        }

        private MedicalSheet _selectedMedicalSheet;
        public ObservableCollection<MedicalSheet> MedicalSheets { get; }
        public Command LoadCommand { get; }
        public Command<MedicalSheet> MSTapped { get; }

        public MedicalSheet SelectedMS
        {
            get => _selectedMedicalSheet;
            set
            {
                _ = SetProperty(ref _selectedMedicalSheet, value);
                OnMSSelected(value);
            }
        }

        #endregion

        #region method
        public MedicalSheetsViewModel()
        {
            Title = "Phiếu khám bệnh";
            MedicalSheets = new ObservableCollection<MedicalSheet>();
            LoadCommand = new Command(async () => await ExecuteLoadCommand());
            Fetch();
            IsBusy = true;
            MSTapped = new Command<MedicalSheet>(OnMSSelected);
        }

        private async Task ExecuteLoadCommand()
        {
            IsBusy = true;
            try
            {
                MedicalSheets.Clear();
                var medicalSheets = await App.SqlBD.GetMedicalSheetsAsync();
                foreach (MedicalSheet m in medicalSheets)
                {
                    MedicalSheets.Add(m);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void Fetch()
        {
            var users = await App.SqlBD.GetUsersAsync();
            var user = users.Where(i => i.Email == Preferences.Get("UserEmail", "")).FirstOrDefault();
            Name_Id = user.Name + " (" + user.Id + ")";
        }

        private async void OnMSSelected(MedicalSheet m)
        {
            if (m == null)
            {
                return;
            }
            // This will push the ItemDetailPage onto the navigation stack
            try
            {
                await Shell.Current.GoToAsync($"{nameof(MedicalSheetDetailPage)}?{nameof(MedicalSheetDetailViewModel.MId)}={m.Id}");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
            }
        }
        #endregion
    }
}
