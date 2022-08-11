using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    public class Bill
    {
        public string Id { get; set; }
        public int PayFeeId { get; set; }
        public DateTime DatePayed { get; set; }
        public string MedicalSheetId { get; set; }
        public string HospitalizationId { get; set; }
    }
}
