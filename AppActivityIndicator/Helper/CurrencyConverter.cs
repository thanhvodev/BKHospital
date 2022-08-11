using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace AppActivityIndicator.Helper
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long strValue = (long)value;
            var info = CultureInfo.GetCultureInfo("vi-VN");
            string tempString = string.Format(info, "{0:C}", strValue);
            //string result = tempString.Substring(0, tempString.Length - 5) + " đ";
            return tempString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
