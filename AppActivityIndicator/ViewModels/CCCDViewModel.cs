using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class CCCDViewModel : BaseViewModel
    {
        #region Field and Property
        public ICommand GetFrontId { get; }
        public ICommand GetBackId { get; }
        private ImageSource _imageSourceFront;
        public ImageSource ImageSourceFront
        {
            get => _imageSourceFront;
            set => _ = SetProperty(ref _imageSourceFront, value);
        }
        #endregion

        #region Method
        public CCCDViewModel()
        {
            GetFrontId = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await Application.Current.MainPage.DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                MediaFile file = null;

                try
                {
                    file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg"
                    });
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
                }

                if (file == null)
                    return;

                await Application.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");

                ImageSourceFront = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            });
        }
        #endregion
    }
}
