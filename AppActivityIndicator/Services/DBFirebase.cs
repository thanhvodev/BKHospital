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
            User s = new User() { Id = $"Ns-{num}", Email = email, Name = "", Sex = "", Street = "", CMND = "", DateOfBirth = DateTime.MinValue, Career = "", Nation = "", Ethic = "", PhoneNo = "", DistrictInx = 0, ProvinceInx = 0, WardInx = 0 };
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
                ProvinceInx = item.Object.ProvinceInx,
                DistrictInx = item.Object.DistrictInx,
                WardInx = item.Object.WardInx,
                Street = item.Object.Street
            }).ToList();
        }

        public async Task UpdateUser(string id, string name, DateTime dateOfBirth, string sex, string cmnd, string career, string nation, string ethic, string phoneNo, string email, int provinceInx, int districtInx,  int wardInx, string street)
        {
            var toUpdateUser = (await client.Child("Users").OnceAsync<User>()).FirstOrDefault(u => u.Object.Email == email);
            User user = new User()
            {
                Id = id,
                Name = name.ToUpper(),
                DateOfBirth = dateOfBirth,
                Sex = sex,
                Career = career,
                Nation = nation,
                Ethic = ethic,
                PhoneNo = phoneNo,
                Email = email,
                CMND = cmnd,
                ProvinceInx = provinceInx,
                DistrictInx = districtInx,
                WardInx = wardInx,
                Street = street
            };
            await client.Child("Users").Child(toUpdateUser.Key).PutAsync(user);
        }
    }
}
