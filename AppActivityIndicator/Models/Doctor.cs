using AppActivityIndicator.Helper;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    public class Doctor
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Specialty { get; set; }
        public string Time { get; set; }
    }
}
