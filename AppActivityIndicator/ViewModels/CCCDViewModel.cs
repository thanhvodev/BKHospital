﻿using AppActivityIndicator.Helper;
using Firebase.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator.ViewModels
{
    public class CCCDViewModel : BaseViewModel
    {
        #region Field and Property
        public ICommand GetFrontId { get; }
        public ICommand GetBackId { get; }

        public Command LoadCommand { get; }

        private ImageSource _imageSourceFront;
        public ImageSource ImageSourceFront
        {
            get => _imageSourceFront;
            set => _ = SetProperty(ref _imageSourceFront, value);
        }

        private ImageSource _imageSourceBack;
        public ImageSource ImageSourceBack
        {
            get => _imageSourceBack;
            set => _ = SetProperty(ref _imageSourceBack, value);
        }
        #endregion

        #region Method
        public CCCDViewModel()
        {
            Title = "Hình CMND/CCCD";
            Fetch();
            LoadCommand = new Command(async () => await ExecuteLoadCommand());
            GetFrontId = new Command(async () =>
            {
                string action = await Application.Current.MainPage.DisplayActionSheet("Chọn ảnh từ?", "Cancel", null, "Thư viện", "Camera");
                if (action == "Camera")
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
                            Name = "front.jpg"
                        });
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
                    }

                    if (file == null)
                        return;

                    //await Application.Current.MainPage.DisplayAlert("File Location", file.Path, "OK");
                    try
                    {
                        var task = await App.FBStorage.InsertStorageWithCapture(file);

                        ImageSourceFront = task;
                        await App.SqlBD.InsertImage(Preferences.Get(Constants.USER_EMAIL_STRING, ""), true, task);
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
                    }
                }
                else if (action == "Camera")
                {
                    var photo = await MediaPicker.PickPhotoAsync();
                    if (photo == null)
                    {
                        return;
                    }
                    var task = await App.FBStorage.InsertStorageWithPick(photo);
                    bool isFront = true;
                    await App.SqlBD.InsertImage(Preferences.Get(Constants.USER_EMAIL_STRING, ""), isFront, task);
                    ImageSourceFront = task;
                }
            });
            GetBackId = new Command(async () =>
            {
                string action = await Application.Current.MainPage.DisplayActionSheet("Chọn ảnh từ?", "Cancel", null, "Thư viện", "Camera");
                if (action == "Camera")
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
                            Name = "back.jpg"
                        });
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
                    }

                    if (file == null)
                        return;

                    try
                    {
                        var task = await App.FBStorage.InsertStorageWithCapture(file);

                        ImageSourceBack = task;
                        bool isFront = false;
                        await App.SqlBD.InsertImage(Preferences.Get(Constants.USER_EMAIL_STRING, ""), isFront, task);
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
                    }

                }
                else if (action == "Camera")
                {
                    var photo = await MediaPicker.PickPhotoAsync();
                    if (photo == null)
                    {
                        return;
                    }
                    var task = await App.FBStorage.InsertStorageWithPick(photo);
                    bool isFront = false;
                    await App.SqlBD.InsertImage(Preferences.Get(Constants.USER_EMAIL_STRING, ""), isFront, task);
                    ImageSourceBack = task;
                }
            });
        }

        private async Task ExecuteLoadCommand()
        {
            IsBusy = true;
            try
            {
                Fetch();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Oops", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void Fetch()
        {
            IsBusy = true;
            try
            {
                ImageSourceFront = await App.SqlBD.GetCMNDNo(Preferences.Get(Constants.USER_EMAIL_STRING, ""), true);
            }
            catch (Exception)
            {
                ImageSourceFront = "";
            }

            try
            {
                ImageSourceBack = await App.SqlBD.GetCMNDNo(Preferences.Get(Constants.USER_EMAIL_STRING, ""), false);
            }
            catch (Exception)
            {
                ImageSourceBack = "";
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion
    }
}
