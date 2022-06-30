using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppActivityIndicator.Helper;
using AppActivityIndicator.Models;
using Firebase.Database;
using Firebase.Database.Query;

namespace AppActivityIndicator.Services
{
    public class DBFirebase
    {
        private readonly FirebaseClient client;

        public DBFirebase()
        {
            client = new FirebaseClient(Constants.FIREBASE_SERVER);
        }

        public async Task AddUser(string email)
        {
            Random rnd = new Random();
            int num = rnd.Next();
            User s = new User() { Id = $"Ns-{num}", Email=email, Name = "", Sex = "", Street = "", CMND = "", DateOfBirth = "", District="", Career = "", Nation="", Ethic="", PhoneNo="", Province="", Ward=""};
            await client.Child("Users").PostAsync(s);
        }
    }
}
