using AppActivityIndicator.Helper;
using AppActivityIndicator.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppActivityIndicator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReSchedulePage : ContentPage
    {
        public ReSchedulePage()
        {
            InitializeComponent();
            BindingContext = new ReSheduleViewModel();
            MedicalSheetIdValidationBehavior.SetAttachBehavior(MedicalSheetId, true);
        }
    }
}