using AppActivityIndicator.Droid.CustomRenderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(Picker), typeof(PickerRender))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace AppActivityIndicator.Droid.CustomRenderers
{
    [Obsolete]
    public class PickerRender : Xamarin.Forms.Platform.Android.PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                this.Control.SetBackground(null);
            }
        }
    }
}