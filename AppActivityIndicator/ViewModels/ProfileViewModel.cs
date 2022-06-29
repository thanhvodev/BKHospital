using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    internal class ProfileViewModel: BaseViewModel
    {
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

        private string country;
        public string Country
        {
            get => country;
            set => _ = SetProperty(ref country, value);
        }

        private string name;
        public string Name
        {
            get => name;
            set => _ = SetProperty(ref name, value);
        }

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

        public ProfileViewModel()
        {
            IsEditing = false;
            BottomButtonText = "Chỉnh sửa";
            Sex = "Nam";
            Country = "Vietnam";
            ProvinceInx = 0;
            Province = "Thành phố Hà Nội"; 
            DistrictInx = 0;
            District = "Quận Ba Đình";
            WardInx = 0;
            Ward = "Phường Phúc Xá";
            EditingCommand = new Command(OnClickEditing);
        }

        private void OnClickEditing()
        {
            IsEditing = !IsEditing;
            BottomButtonText = IsEditing ? "Lưu" : "Chỉnh sửa";
        }
    }
}
