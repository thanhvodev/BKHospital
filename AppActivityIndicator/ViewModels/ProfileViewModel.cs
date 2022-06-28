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
            EditingCommand = new Command(OnClickEditing);
        }

        private void OnClickEditing()
        {
            IsEditing = !IsEditing;
            BottomButtonText = IsEditing ? "Lưu" : "Chỉnh sửa";
        }
    }
}
