using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class UserManualViewModel : BaseViewModel
    {
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public UserManualViewModel()
        {
            Title = "Hướng dẫn sử dụng";
        }
    }
}
