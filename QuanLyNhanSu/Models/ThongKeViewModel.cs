using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class ThongKeViewModel
    {
        public List<int> DSLuongThang {  get; set; }
        
        public decimal TongChi { get; set; }
        public string Title { get; set; }
    }
}