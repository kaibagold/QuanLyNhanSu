using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class ThongKeController : Controller
    {
        QuanLyNhanSuEntities db;
        public ThongKeController()
        {
            db = new QuanLyNhanSuEntities();
        }

        public ActionResult Index()
        {
            ThongKeViewModel model = new ThongKeViewModel();
            model.DSLuongThang = Enumerable.Range(0, 12)
                .ToList();
            
            var dsLuong = db.ChiTietLuongs.Where(x => x.NgayNhanLuong.Year == DateTime.Now.Year)
                .ToList();
            
            decimal tongLuongDaPhat = 0;
            
            List<decimal> tongKetLuongThang = new List<decimal>()
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
            };

            foreach (var item in dsLuong)
            {
                if (decimal.TryParse(item.TongTienLuong, out decimal tienLuong))
                {
                    tongLuongDaPhat += tienLuong;
                    tongKetLuongThang[item.NgayNhanLuong.Month - 1] += tienLuong;
                } 
            }
            
            model.TongChi = tongLuongDaPhat;

            for (int i = 0; i < 12; i++)
            {
                model.DSLuongThang[i] = (int)tongKetLuongThang[i];
            } 

            model.Title = "Thống kê lương tháng 1 - 12 năm " + DateTime.Now.Year.ToString();
            return View(model);
        }
    }
}