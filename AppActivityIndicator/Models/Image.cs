using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppActivityIndicator.Models
{
    public class Image
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; }
        public bool IsFront { get; set; }
        public string Src { get; set; }
    }
}
