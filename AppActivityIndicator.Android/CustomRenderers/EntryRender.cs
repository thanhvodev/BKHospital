using AppActivityIndicator.Droid.CustomRenderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(Entry), typeof(EntryRender))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace AppActivityIndicator.Droid.CustomRenderers
{
    [Obsolete]
    public class EntryRender : Xamarin.Forms.Platform.Android.EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                this.Control.SetBackground(null);
            }
        }
    }
}