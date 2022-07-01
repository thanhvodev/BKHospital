using AppActivityIndicator.Helper;
using AppActivityIndicator.Models;
using Firebase.Database;
using Firebase.Database.Query;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppActivityIndicator.Services
{
    public class DBSqlite
    {
        private readonly SQLiteAsyncConnection sqlDB;
        private readonly FirebaseClient client;
        public DBSqlite(string dbPath)
        {
            client = new FirebaseClient(Constants.FIREBASE_SERVER);
            sqlDB = new SQLiteAsyncConnection(dbPath);
            sqlDB.CreateTableAsync<User>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return sqlDB.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(string email)
        {
            return sqlDB.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task UpdateUserAsync(string id, string name, DateTime dateOfBirth, string sex, string cmnd, string career, string nation, string ethic, string phoneNo, string email, int provinceInx, int districtInx, int wardInx, string street)
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

            _ = sqlDB.UpdateAsync(user);
            await client.Child("Users").Child(toUpdateUser.Key).PutAsync(user);
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (!string.IsNullOrEmpty(user.Id))
            {
                return sqlDB.UpdateAsync(user);
            }
            else
            {
                return sqlDB.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return sqlDB.DeleteAsync(user);
        }

        public async Task<FirebaseObject<User>> AddUser(string email)
        {
            Random rnd = new Random();
            int num = rnd.Next();
            User user = new User() { Id = $"Ns-{num}", Email = email, Name = "", Sex = "", Street = "", CMND = "", DateOfBirth = DateTime.MinValue, Career = "", Nation = "Vietnam", Ethic = "", PhoneNo = "", DistrictInx = 0, ProvinceInx = 0, WardInx = 0 };
            _ = sqlDB.InsertAsync(user);
            return await client.Child("Users").PostAsync(user);
        }
    }
}
