using AppActivityIndicator.Helper;
using Firebase.Storage;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppActivityIndicator.Services
{
    public class DBFirebaseStorage
    {
        private readonly FirebaseStorage client;

        public DBFirebaseStorage()
        {
            client = new FirebaseStorage(Constants.FIREBASE_BUCKET, new FirebaseStorageOptions
            {
                ThrowOnCancel = true
            });
        }

        public FirebaseStorageTask InsertStorageWithCapture(MediaFile file)
        {
            return client.Child("CMND")
                         .Child($"{file.GetHashCode()}.png")
                         .PutAsync(file.GetStream());
        }

        public async Task InsertStorageWithPick(FileResult file)
        {
            await client.Child("CMND")
                         .Child(file.FileName)
                         .PutAsync(await file.OpenReadAsync());
        }
    }
}
