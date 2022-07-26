using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppActivityIndicator.Models
{
    public class Fee
    {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ulong PhiKhamBenh { get; set; }
        public ulong PhiPhauThuat { get; set; }
        public ulong PhiThuoc { get; set; }
        public ulong PhiAnUong { get; set; }
        public ulong PhiDieuDuong { get; set; }
        public ulong PhiONoiTru { get; set; }

    }
}
