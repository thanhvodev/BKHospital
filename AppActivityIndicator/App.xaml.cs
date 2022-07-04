using AppActivityIndicator.Services;
using AppActivityIndicator.Views;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppActivityIndicator
{
    public partial class App : Application
    {

        private static DBSqlite sqlDB;

        // Create the database connection as a singleton.
        public static DBSqlite SqlBD
        {
            get
            {
                if (sqlDB == null)
                {
                    sqlDB = new DBSqlite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3"));
                }
                return sqlDB;
            }
        }

        private static DBFirebase fireDB;

        // Create the database connection as a singleton.
        public static DBFirebase FireDB
        {
            get
            {
                if (fireDB == null)
                {
                    fireDB = new DBFirebase();
                }
                return fireDB;
            }
        }

        private static API api;

        // Create the database connection as a singleton.
        public static API API
        {
            get
            {
                if (api == null)
                {
                    api = API.GetInstance();
                }
                return api;
            }
        }


        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            if (!string.IsNullOrEmpty(Preferences.Get("MyFirebaseRefreshToken", "")))
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new AppShell();
               // MainPage = new NavigationPage(new LoginPage());
                Shell.Current.GoToAsync("//LoginPage");
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
