using AppActivityIndicator.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class MASuccessViewModel : BaseViewModel
    {
        public MASuccessViewModel()
        {
            BackToHomeCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//AboutPage");
            });
        }

        public ICommand BackToHomeCommand { get; }
    }
}
