using AppActivityIndicator.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppActivityIndicator.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}