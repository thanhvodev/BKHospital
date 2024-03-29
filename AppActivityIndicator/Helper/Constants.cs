﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Helper
{
    internal static class Constants
    {
        public const string WebAPIkey = "AIzaSyByvkhjHZkNebFbUUO4dYZRLqmN0q6d1ik";
        public const string ProvinceAPIEndpoint = "https://provinces.open-api.vn";
        public const string CountryAPIEndpoint = "https://restcountries.com";
        public const string FIREBASE_SERVER = "https://xamarinauth-462c8-default-rtdb.firebaseio.com/";
        public const string QR_API_ENDPOINT = "https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=";
        public const string HOSPITAL_ADDRESS = "HCMC+National+University+Dormitary+Zone+A";
        public const string SUPPORT_PHONE_NUMBER = "196478536";
        public const string USER_EMAIL_STRING = "UserEmail";
        public const string FIREBASE_BUCKET = "xamarinauth-462c8.appspot.com";
        public const string MEDICAL_SHEET_ID_REGEX = @"^AS-[0-9]+$";
        public const string HOSPITALIZATION_ID_REGEX = @"^[0-9][0-9]-[0-9]+$";
        public const string EMAIL_AUTHORIZATION_TOKEN = "Basic MDQwYTk0OWI0OGUxNmIyM2Y2MWEyMzI3ZDRhNjMxNWI6YjliNGM0NzZiZTc2NmEzN2RkYmJiYjA1ZDYwMWY3ZWQ=";
        public const string APPLICATION_TYPE = "application/json";
    }
}
