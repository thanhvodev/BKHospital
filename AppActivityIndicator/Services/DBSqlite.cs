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
using Xamarin.Essentials;
using Xamarin.Forms;

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
            sqlDB.CreateTableAsync<Country>().Wait();
            sqlDB.CreateTableAsync<Doctor>().Wait();
            sqlDB.CreateTableAsync<Specialty>().Wait();
            sqlDB.CreateTableAsync<Room>().Wait();
            sqlDB.CreateTableAsync<MedicalSheet>().Wait();

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

        public async Task FetchDataToLocal()
        {
            List<Country> countries = await App.API.GetCountrysAsync($"{Constants.CountryAPIEndpoint}/v2/all/");
            foreach (var country in countries)
            {
                await sqlDB.InsertAsync(country);
            }

            List<Doctor> doctors = (await client.Child("Doctor").OnceAsync<Doctor>()).Select(d => new Doctor()
            {
                Id = d.Object.Id,
                Name = d.Object.Name,
                Specialty = d.Object.Specialty,
                Time = d.Object.Time
            }).ToList();
            foreach (var doctor in doctors)
            {
                _ = sqlDB.InsertAsync(doctor);
            }


            List<Specialty> specialties = (await client.Child("specialty").OnceAsync<Specialty>()).Select(s => new Specialty()
            {
                Id = s.Object.Id,
                Name = s.Object.Name
            }).ToList();
            foreach (var specialty in specialties)
            {
                _ = sqlDB.InsertAsync(specialty);
            }

            List<MedicalSheet> medicalSheets = (await client.Child("MedicalSheet").OnceAsync<MedicalSheet>()).Select(m => new MedicalSheet()
            {
                Id = m.Object.Id,
                Address = m.Object.Address,
                Time = m.Object.Time,
                Date = m.Object.Date,
                UserId = m.Object.UserId,
                RoomName = m.Object.RoomName,
                STT = m.Object.STT,
                SpecialtyId = m.Object.SpecialtyId,
                DoctorName = m.Object.DoctorName,
                State = m.Object.State,
                SpecialtyName = m.Object.SpecialtyName
            }).ToList();
            foreach (var medicalSheet in medicalSheets)
            {
                _ = sqlDB.InsertAsync(medicalSheet);
            }

            List<Room> rooms = (await client.Child("Room").OnceAsync<Room>()).Select(m => new Room()
            {
                Id = m.Object.Id,
                Name = m.Object.Name,
                Specialty = m.Object.Specialty
            }).ToList();
            foreach (var room in rooms)
            {
                _ = sqlDB.InsertAsync(room);
            }



            List<User> users = (await client.Child("Users").OnceAsync<User>()).Select(u => new User()
            {
               Id = u.Object.Id,
               Name = u.Object.Name,
               Sex = u.Object.Sex,
               Street = u.Object.Street,
               CMND = u.Object.CMND,
               DateOfBirth = u.Object.DateOfBirth,
               Career = u.Object.Career,
               Nation = u.Object.Nation,
               Ethic = u.Object.Ethic,
               PhoneNo = u.Object.PhoneNo,
               DistrictInx = u.Object.DistrictInx,
               ProvinceInx = u.Object.ProvinceInx,
               WardInx = u.Object.WardInx,
               Email = u.Object.Email
            }).ToList();
            foreach (var user in users)
            {
                _ = sqlDB.InsertAsync(user);
            }
        }

        public async Task<int> ClearLocal()
        {
            await sqlDB.DeleteAllAsync<User>();
            await sqlDB.DeleteAllAsync<Doctor>();
            await sqlDB.DeleteAllAsync<Specialty>();
            await sqlDB.DeleteAllAsync<Country>();
            await sqlDB.DeleteAllAsync<MedicalSheet>();
            await sqlDB.DeleteAllAsync<Room>();
            return 1;
        }

        public async Task<List<Country>> GetCountrys()
        {
            return await sqlDB.Table<Country>().ToListAsync();
        }

        public async Task<List<Doctor>> GetDoctors(int specialty)
        {
            List<Doctor> doctors = await sqlDB.Table<Doctor>().ToListAsync();
            List<Doctor> Fdoctor = doctors.FindAll(x => x.Specialty == specialty);
            //await Application.Current.MainPage.DisplayAlert("Thành công", $"{Fdoctor.Count}", "OK");
            return Fdoctor;
        }

        public async Task<List<string>> GetTimes(string doctorName)
        {
            List<Doctor> doctors = await sqlDB.Table<Doctor>().ToListAsync();
            Doctor d = doctors.Find(x => x.Name == doctorName);
            List<string> src = d.Time.Split(',').ToList();
            return src;
        }

        public async Task<List<Specialty>> GetSpecialties()
        {   
            return await sqlDB.Table<Specialty>().ToListAsync();
        }

        public async Task InsertMedicalSheetAsync(string mId, string doctorName, string time, DateTime date, int specialty, string email, string specialtyName)
        {
            Random rnd = new Random();
            int num = rnd.Next();
            User user = await sqlDB.Table<User>().Where(u => u.Email == email).FirstOrDefaultAsync();
            Room room = await sqlDB.Table<Room>().Where(r =>r.Specialty == specialty).FirstOrDefaultAsync();
            MedicalSheet medicalSheet = new MedicalSheet()
            {
                Id = mId,
                DoctorName = doctorName,
                Time = time,
                Date = date,
                SpecialtyId = specialty,
                Address = "268 Lý Thường Kiệt, P. 14, Q.10, Tp. Hồ Chí Minh",
                State = "Chưa khám",
                STT = rnd.Next(1, 50),
                UserId = user.Id,
                RoomName = room.Name,
                SpecialtyName = specialtyName
            };
            _ = sqlDB.InsertAsync(medicalSheet) ;
            await client.Child("MedicalSheet").PostAsync(medicalSheet);
        }

        public async Task<MedicalSheet> GetMedicalSheet(string mId)
        {
            MedicalSheet medicalSheet = await sqlDB.Table<MedicalSheet>().Where(m => m.Id == mId).FirstOrDefaultAsync();
            return medicalSheet;
        }

        public async Task<List<MedicalSheet>> GetMedicalSheetsAsync(string mId)
        {
            List<MedicalSheet> result = (await sqlDB.Table<MedicalSheet>().ToListAsync()).FindAll(m => m.UserId == mId);
            DateTime today = DateTime.Now;
            foreach (MedicalSheet medicalSheet in result)
            {
                if (DateTime.Compare(today, medicalSheet.Date) > 0)
                {
                    var toUpdateMS = (await client.Child("MedicalSheet").OnceAsync<MedicalSheet>()).FirstOrDefault(u => u.Object.Id == medicalSheet.Id);
                    medicalSheet.State = "Đã khám";
                    _ = sqlDB.UpdateAsync(medicalSheet);
                    await client.Child("MedicalSheet").Child(toUpdateMS.Key).PutAsync(medicalSheet);
                }
            }
            return result;
        }
    }
}