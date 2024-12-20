using Microsoft.Ajax.Utilities;
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

        public ActionResult Index(String year)
        {
            int selectedYear = DateTime.Now.Year;
            if (year != null)
                selectedYear = Convert.ToInt32(year);
            ThongKeViewModel model = new ThongKeViewModel();
            model.DSLuongThang = Enumerable.Range(0, 12).ToList();
            
            var dsLuong = db.ChiTietLuongs.Where(x => x.NgayNhanLuong.Year == selectedYear).ToList();
            var nhanvien = db.NhanViens.ToList();
            var swap = db.ChiTietSwaps.Where(x => x.ThoiGianNhanCa.Year == selectedYear).ToList();
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
            model.Title = "Thống kê lương tháng 1 - 12 năm " + selectedYear;
            //lương theo quý
            var dsLuongQuy = dsLuong
            .GroupBy(l => new { Quarter = (l.NgayNhanLuong.Month - 1) / 3 + 1, Year = l.NgayNhanLuong.Year })
            .Select(g => new
            {
                Quarter = g.Key.Quarter,
                Year = g.Key.Year,
                TotalSalary = g.Sum(x => Convert.ToDecimal(x.TongTienLuong)) // Chuyển đổi từ varchar sang decimal
            })
            .ToList();
            ViewBag.dsLuongQuy = dsLuongQuy;
            //lương theo phòng ban
            var dsLuongPhongBan = dsLuong
           .Join(nhanvien,
                 luong => luong.MaNhanVien,
                 nhanVien => nhanVien.MaNhanVien,
                 (luong, nhanVien) => new
                 {
                     nhanVien.MaPhongBan,
                     luong.TongTienLuong
                 })
           .GroupBy(x => x.MaPhongBan)
           .Select(g => new
           {
               MaPhongBan = g.Key,
               TongLuong = g.Sum(x => Convert.ToDecimal(x.TongTienLuong))
           })
           .ToList();
            ViewBag.dsLuongPhongBan = dsLuongPhongBan;
            //thống kê ca swap
            var dsSwap = swap
           .GroupBy(l => new { Month = l.ThoiGianNhanCa.Month, Year = l.ThoiGianNhanCa.Year })
           .Select(g => new
           {
               Month = g.Key.Month,
               Year = g.Key.Year,
               Count = g.Count() // Chuyển đổi từ varchar sang decimal
           })
           .OrderBy(m => m.Year).ThenBy(m => m.Month) // Sắp xếp theo năm và tháng
           .ToList();
            ViewBag.dsSwap = dsSwap;
            return View(model);
        }      
    }
}