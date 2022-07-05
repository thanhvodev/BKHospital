using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    public class Specialty
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }   
}
