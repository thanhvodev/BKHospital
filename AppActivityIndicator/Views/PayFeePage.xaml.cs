﻿using AppActivityIndicator.Helper;
using AppActivityIndicator.ViewModels;
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
    public partial class PayFeePage : ContentPage
    {
        public PayFeePage()
        {
            InitializeComponent();
            BindingContext = new PayFeeViewModel();
            MedicalSheetIdValidationBehavior.SetAttachBehavior(ProfileNumber, true);
            HospitalizationIdValidationBehavior.SetAttachBehavior(HospitalizationNumber, true);
            ProfileNumber.Text = "AS-1234567";
            HospitalizationNumber.Text = "18-01234567";

        }

        private void ProfileNumber_TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ProfileNumber.Focus();
        }

        private void HospitalizationNumber_TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            HospitalizationNumber.Focus();
        }
    }
}