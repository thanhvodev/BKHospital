using AppActivityIndicator.ViewModels;
using AppActivityIndicator.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppActivityIndicator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MASuccessPage : ContentPage
    {
        public MASuccessPage()
        {
            InitializeComponent();
            BindingContext = new MASuccessViewModel();
            NavigationPage.SetBackButtonTitle(this, "");
        }
    }
}