using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    public class MedicalSheet
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string DoctorName { get; set; }
        public string RoomName { get; set; }
        public int STT { get; set; }
        public int SpecialtyId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string Time { get; set; }
        public string UserId { get; set; }
        public string State { get; set; }
    }
}
