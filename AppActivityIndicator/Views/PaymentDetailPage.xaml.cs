﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppActivityIndicator.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppActivityIndicator.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaymentDetailPage : ContentPage
    {
        public PaymentDetailPage()
        {
            InitializeComponent();
            BindingContext = new PaymentDetailViewModel();
        }
    }
}