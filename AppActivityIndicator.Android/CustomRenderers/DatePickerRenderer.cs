using AppActivityIndicator.Droid.CustomRenderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(DatePicker), typeof(DatePickerRender))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace AppActivityIndicator.Droid.CustomRenderers
{
    [Obsolete]
    public class DatePickerRender : Xamarin.Forms.Platform.Android.DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackground(null);
            }
        }
    }
}