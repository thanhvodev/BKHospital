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
        public long PhiKhamBenh { get; set; }
        public long PhiPhauThuat { get; set; }
        public long PhiThuoc { get; set; }
        public long PhiAnUong { get; set; }
        public long PhiDieuDuong { get; set; }
        public long PhiONoiTru { get; set; }

    }
}
