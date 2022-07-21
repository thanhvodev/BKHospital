using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace AppActivityIndicator.Helper
{
    public static class MedicalSheetIdValidationBehavior
    {
        public static readonly BindableProperty AttachBehaviorProperty =
            BindableProperty.CreateAttached(
                "AttachBehavior",
                typeof(bool),
                typeof(MedicalSheetIdValidationBehavior),
                false,
                propertyChanged: OnAttachBehaviorChanged);

        public static bool GetAttachBehavior(BindableObject view)
        {
            return (bool)view.GetValue(AttachBehaviorProperty);
        }

        public static void SetAttachBehavior(BindableObject view, bool value)
        {
            view.SetValue(AttachBehaviorProperty, value);
        }

        private static void OnAttachBehaviorChanged(BindableObject view, object oldValue, object newValue)
        {
            Entry entry = view as Entry;
            if (entry == null)
            {
                return;
            }

            bool attachBehavior = (bool)newValue;
            if (attachBehavior)
            {
                entry.TextChanged += OnEntryTextChanged;
            }
            else
            {
                entry.TextChanged -= OnEntryTextChanged;
            }
        }

        private static void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            string pattern = Constants.MEDICAL_SHEET_ID_REGEX;
            bool isValid = Regex.IsMatch(args.NewTextValue, pattern);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
