using System;
using System.Collections.Generic;
using System.Linq;
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
            User s = new User() { Id = $"Ns-{num}", Email = email, Name = "", Sex = "", Street = "", CMND = "", DateOfBirth = DateTime.MinValue, District = "", Career = "", Nation = "", Ethic = "", PhoneNo = "", Province = "", Ward = "", DistrictInx = -1, ProvinceInx = -1, WardInx = -1 };
            await client.Child("Users").PostAsync(s);
        }

        public async Task<List<User>> GetUsers()
        {
            return (await client.Child("Users").OnceAsync<User>()).Select(item => new User
            {
                Id = item.Object.Id,
                Name = item.Object.Name,
                DateOfBirth = item.Object.DateOfBirth,
                Sex = item.Object.Sex,
                CMND = item.Object.CMND,
                Career = item.Object.Career,
                Nation = item.Object.Nation,
                Ethic = item.Object.Ethic,
                PhoneNo = item.Object.PhoneNo,
                Email = item.Object.Email,
                Province = item.Object.Province,
                ProvinceInx = item.Object.ProvinceInx,
                District = item.Object.District,
                DistrictInx = item.Object.DistrictInx,
                Ward = item.Object.Ward,
                WardInx = item.Object.WardInx,
                Street = item.Object.Street
            }).ToList();
        }
    }
}
