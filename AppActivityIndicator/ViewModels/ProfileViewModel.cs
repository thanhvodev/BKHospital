using AppActivityIndicator.Models;
using AppActivityIndicator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;
using AppActivityIndicator.Views;

namespace AppActivityIndicator.ViewModels
{
    [QueryProperty(nameof(FromId), nameof(FromId))]
    public class ProfileViewModel: BaseViewModel
    {
        private string fromId;
        public string FromId
        {
            get => fromId;
            set => _ = SetProperty(ref fromId, value);
        }

        #region bind user data
        private string street;
        public string Street
        {
            get => street;
            set => _ = SetProperty(ref street, value);
        }

        private string email;
        public string Email
        {
            get => email;
            set => _ = SetProperty(ref email, value);
        }

        private string phoneNo;
        public string PhoneNo
        {
            get => phoneNo;
            set => _ = SetProperty(ref phoneNo, value);
        }

        private string ethic;
        public string Ethic
        {
            get => ethic;
            set => _ = SetProperty(ref ethic, value);
        }

        private string nation;
        public string Nation
        {
            get => nation;
            set => _ = SetProperty(ref nation, value);
        }

        private string carrer;
        public string Career
        {
            get => carrer;
            set => _ = SetProperty(ref carrer, value);
        }

        private string cmnd;
        public string CMND
        {
            get => cmnd;
            set => _ = SetProperty(ref cmnd, value);
        }

        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set => _ = SetProperty(ref dateOfBirth, value);
        }

        private string id;
        public string Id
        {
            get => id;
            set => _ = SetProperty(ref id, value);
        }

        private string sex;
        public string Sex
        {
            get => sex;
            set => _ = SetProperty(ref sex, value);
        }

        private string province;
        public string Province
        {
            get => province;
            set => _ = SetProperty(ref province, value);
        }

        private int provinceInx;
        public int ProvinceInx
        {
            get => provinceInx;
            set => _ = SetProperty(ref provinceInx, value);
        }

        private string district;
        public string District
        {
            get => district;
            set => _ = SetProperty(ref district, value);
        }

        private int districtInx;
        public int DistrictInx
        {
            get => districtInx;
            set => _ = SetProperty(ref districtInx, value);
        }

        private string ward;
        public string Ward
        {
            get => ward;
            set => _ = SetProperty(ref ward, value);
        }

        private int wardInx;
        public int WardInx
        {
            get => wardInx;
            set => _ = SetProperty(ref wardInx, value);
        }

        private string name;
        public string Name
        {
            get => name;
            set => _ = SetProperty(ref name, value);
        }
        #endregion bind user data
        private bool isEditing;
        public bool IsEditing
        {
            get => isEditing;
            set => _ = SetProperty(ref isEditing, value);
        }

        private string bottomButtonText;
        public string BottomButtonText
        {
            get => bottomButtonText;
            set => _ = SetProperty(ref bottomButtonText, value);
        }
        public Command EditingCommand { get;}
        public Command BackBehavior { get; }

        public ProfileViewModel()
        {
            IsEditing = false;
            BottomButtonText = "Chỉnh sửa";
            FetchUserData();
            EditingCommand = new Command(OnClickEditing);
            BackBehavior = new Command(async () =>
            {
                try
                {
                    if (FromId == "HomePage")
                    {
                        await Shell.Current.GoToAsync("..");
                    }
                    else
                    {
                        await Shell.Current.GoToAsync($"{nameof(MakingAppointmentPage)}");
                    }
                }
                catch (Exception)
                {
                    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                    //await Application.Current.MainPage.DisplayAlert("Alert", "Broken", "OK");
                }
            });
        }

        private async void FetchUserData()
        {
            try
            {
                //var users = await services.GetUsers();
                var users = await App.SqlBD.GetUsersAsync();
                var user = users.Where(i => i.Email == Preferences.Get("UserEmail", "")).FirstOrDefault();
                Id = user.Id;
                Name = user.Name;
                DateOfBirth = user.DateOfBirth;
                Sex = user.Sex;
                CMND = user.CMND;
                Career = user.Career;
                Nation = user.Nation;
                Ethic = user.Ethic;
                PhoneNo = user.PhoneNo;
                Email = user.Email;
                ProvinceInx = user.ProvinceInx;
                DistrictInx = user.DistrictInx;
                WardInx = user.WardInx;
                Street = user.Street;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Lấy dữ liệu bị lỗi", ex.Message, "OK");
            }
        }

        private async void OnClickEditing()
        {
            if (IsEditing)
            {
                try
                {
                    await App.SqlBD.UpdateUserAsync(Id, Name, DateOfBirth, Sex, CMND, Career, Nation, Ethic, PhoneNo, Email, ProvinceInx, DistrictInx, WardInx, Street);
                    await Application.Current.MainPage.DisplayAlert("Thành công", "Lưu thông tin thành công", "OK");
                }
                catch (Exception)
                {
                    await Application.Current.MainPage.DisplayAlert("Thất bại", "Lưu thông tin thất bại", "OK");
                }
            }
            IsEditing = !IsEditing;
            BottomButtonText = IsEditing ? "Lưu" : "Chỉnh sửa";
        }
    }
}
