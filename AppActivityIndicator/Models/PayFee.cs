using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    public class PayFee
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int FeeId { get; set; }
        public string HospitalizationNumber { get; set; }
        public string ProfileNumber { get; set; }
    }
}
