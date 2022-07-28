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
    public class PaymentsViewModel : BaseViewModel
    {

        private string name_id;
        public string Name_Id
        {
            get => name_id;
            set => _ = SetProperty(ref name_id, value);
        }

        public ObservableCollection<Bill> Bills { get; set; }
        public Command BackToHomeCommand { get; }
        public Command LoadCommand { get; }
        public PaymentsViewModel()
        {
            IsBusy = true;
            Title = "Các khoản đã thanh toán";
            Bills = new ObservableCollection<Bill>();
            Fetch();
            BackToHomeCommand = new Command(async () => await Shell.Current.GoToAsync($"//{nameof(AboutPage)}"));
            LoadCommand = new Command(async () => await ExecuteLoadCommand());
        }

        private async Task ExecuteLoadCommand()
        {
            IsBusy = true;
            try
            {
                Bills.Clear();
                List<Bill> localBill = await App.SqlBD.GetAllBillsAsync();
                foreach (Bill bill in localBill)
                {
                    Bills.Add(bill);
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
    }
}
