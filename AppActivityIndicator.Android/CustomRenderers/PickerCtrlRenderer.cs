using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using AppActivityIndicator.CustomControls;
using DatePickerDefaultTextDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(PickerCtrl), typeof(PickerCtrlRenderer))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace DatePickerDefaultTextDemo.Droid
{
    [Obsolete]
    public class PickerCtrlRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            //Control.SetTextColor(Android.Graphics.Color.Rgb(83, 63, 149));
            Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            Control.SetPadding(20, 0, 0, 0);

            GradientDrawable gd = new GradientDrawable();
            gd.SetCornerRadius(25); //increase or decrease to changes the corner look  
            gd.SetColor(Android.Graphics.Color.Transparent);
            //gd.SetStroke(3, Android.Graphics.Color.Rgb(83, 63, 149));

            Control.SetBackgroundDrawable(gd);

            PickerCtrl element = Element as PickerCtrl;

            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }

            Control.TextChanged += (sender, arg) => {
                var selectedDate = arg.Text.ToString();
                if (selectedDate == element.Placeholder)
                {
                    Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            };
        }
    }
}