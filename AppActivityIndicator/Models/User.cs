﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string CMND { get; set; }
        public string Career { get; set; }
        public string Nation { get; set; }
        public string Ethic { get; set; }
        public string PhoneNo { get; set;}
        [PrimaryKey]
        public string Email { get; set; }
        public int ProvinceInx { get; set; }
        public int DistrictInx { get; set; }
        public int WardInx { get; set; }
        public string Street { get; set; }
    }
}
