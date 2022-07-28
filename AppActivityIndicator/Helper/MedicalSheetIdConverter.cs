using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppActivityIndicator.Helper
{
    public class MedicalSheetIdConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public async Task<object> ConvertAsync(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string billId = (string)value;
            string medicalSheetId = await App.SqlBD.GetMedicalSheetIdAsync(billId);
            return medicalSheetId;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
