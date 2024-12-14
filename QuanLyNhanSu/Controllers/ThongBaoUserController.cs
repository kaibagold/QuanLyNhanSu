using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class ThongBaoUserController : Controller
    {
        // GET: ThongBao
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        public ActionResult Index()
        {
            if(Session["MaNhanVien"]!=null)
            {
                string MaNV = Session["MaNhanVien"].ToString();
                var tb = db.ThongBaos.Where(n => n.MaNVNhanTB == MaNV).OrderByDescending(n => n.Id).ToList();
                return View(tb);
            }
            return RedirectToAction("Login", "login");
        }
        public ActionResult ChiTietThongBao(int id)
        {
            if (Session["MaNhanVien"] != null)
            {
                string MaNV = Session["MaNhanVien"].ToString();
                var tb = db.ThongBaos.Where(n => n.Id == id).FirstOrDefault();
                tb.ThoiGianDuyetTB = DateTime.Now;
                tb.TrangThai = 2;
                db.SaveChanges();
                if (tb.LoaiThongBao == "nhanvattu")
                {
                    return Redirect("~/NhanVien/TamUngVatTu");
                }
                if (tb.LoaiThongBao == "nhanca")
                {
                    return Redirect("~/NhanVien/NhanCaSwap");
                }
                if (tb.LoaiThongBao == "capmatkhau")
                {
                    return Redirect("https://mail.google.com/");
                }
            }
            return RedirectToAction("Login", "login");
        }
        public static string GetTimeSinceNotification(DateTime notificationTime)
        {
            // Lấy thời gian hiện tại
            DateTime currentTime = DateTime.Now;

            // Tính khoảng thời gian đã trôi qua
            TimeSpan timeElapsed = currentTime - notificationTime;

            // Kiểm tra xem thời gian đã trôi qua có âm không
            if (timeElapsed.TotalSeconds <= 0)
            {
                return "vài giây trước.";
            }

            // Tạo chuỗi kết quả
            string result = "";
            // Thêm ngày
            if (timeElapsed.Days > 0)
            {
                result += $"{timeElapsed.Days} ngày ";
            }
            else
            {
                // Thêm giờ
                if (timeElapsed.Hours > 0)
                {
                    result += $"{timeElapsed.Hours} giờ ";
                }

                // Thêm phút
                if (timeElapsed.Minutes > 0)
                {
                    result += $"{timeElapsed.Minutes} phút ";
                }
            }

            // Thêm từ "trước" vào cuối
            result += "trước";

            return result.Trim(); // Trim để loại bỏ khoảng trắng thừa
        }
    }
}