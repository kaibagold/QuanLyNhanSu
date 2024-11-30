using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Controllers
{
    public class NhanVienController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        //
        // GET: /NhanVien/
        public ActionResult Index()
        {
            var id = Session["MaNhanVien"] as string;
            var chitiet = db.ChiTietLuongs.Where(n => n.MaNhanVien == id).ToList();
            return View(chitiet);
        }
        [HttpPost]
        public ActionResult YourAjaxAction(int selectedMonth)
        {
            Session["selectedMonth"] = selectedMonth;
            return Redirect("~/NhanVien");
        }
        public string convertMonth(string month)
        {
            // Lấy phần chuỗi từ vị trí sau ký tự đầu tiên
            if (month.Length > 1 && month[0] == 't')
            {
                return month.Substring(1); // Bỏ đi ký tự 't' ở đầu chuỗi
            }
            return month; // Trả lại chuỗi gốc nếu không có ký tự 't' ở đầu
        }
        [HttpGet]
        public ActionResult NhanCaSwap(string id)
        {
            if(Session["MaNhanVien"] != null)
            {
                var sw = db.Swaps.Where(n => n.MaNVTrienKhai == id).ToList();
                //SwapValidate swVal = new SwapValidate();
                //swVal.Id = sw.Id;
                //swVal.MaHopDong = sw.MaHopDong;
                //swVal.SdtKhachHang = sw.SdtKhachHang;
                //swVal.KhuVuc = sw.KhuVuc;
                //swVal.TenKhachHang = sw.TenKhachHang;
                //swVal.MaNVTrienKhai = sw.MaNVTrienKhai;
                //swVal.PhiDichVu = sw.PhiDichVu;
                return View(sw);
            }
            return RedirectToAction("Login", "login");
        }

        [HttpPost]
        public ActionResult CapNhatTrangThai(int id)
        {
            // Tìm user theo ID
            var sw = db.Swaps.FirstOrDefault(u => u.Id == id);
            if (sw == null)
            {
                return Redirect("/"); // Trả về 404 nếu không tìm thấy user
            }

            // Cập nhật trạng thái swap
            sw.TrangThai = 2;
            //Thêm record mới vào bảng ChiTietSwap
            ChiTietSwap ChiTietsw = new ChiTietSwap();
            ChiTietsw.MaHopDong = sw.MaHopDong;
            ChiTietsw.TenKhachHang = sw.TenKhachHang;
            ChiTietsw.SdtKhachHang = sw.SdtKhachHang;
            ChiTietsw.DiaChiKH = sw.DiaChiKH;
            ChiTietsw.KhuVuc = sw.KhuVuc;
            ChiTietsw.MaNVLenPhieu = sw.MaNVLenPhieu;
            ChiTietsw.MaNVTrienKhai = sw.MaNVTrienKhai;
            ChiTietsw.SdtSale = sw.SdtSale;
            ChiTietsw.SaleNote = sw.SaleNote;
            ChiTietsw.PhiDichVu = sw.PhiDichVu;
            ChiTietsw.ThoiGianNhanCa = DateTime.Now;
            //ChiTietsw.DanhGia = sw.MaHopDong;
            ChiTietsw.TrangThai = 0;//đang triển khai
            db.ChiTietSwaps.Add(ChiTietsw);
            db.SaveChanges(); // Lưu thay đổi vào database
            // Trả về JSON hoặc Redirect đến view gốc
            return Json(new { success = true, status = sw.TrangThai });
        }
        public ActionResult ChiTietSwap(int id)
        {
            var sw = db.Swaps.Where(n => n.Id == id).FirstOrDefault();
            SwapValidate swVal = new SwapValidate();
            swVal.Id = sw.Id;
            swVal.MaHopDong = sw.MaHopDong;
            swVal.SdtKhachHang = sw.SdtKhachHang;
            swVal.KhuVuc = sw.KhuVuc;
            swVal.NgayTaoHD = (DateTime)sw.NgayTaoHD;
            swVal.DiaChiKH = sw.DiaChiKH;
            swVal.TenKhachHang = sw.TenKhachHang;
            swVal.MaNVTrienKhai = sw.MaNVTrienKhai;
            swVal.PhiDichVu = sw.PhiDichVu;
            return View(swVal);
        }
        [HttpGet]
        public ActionResult TrienKhaiSwap(int id)
        {
            var sw = db.Swaps.Where(n => n.Id == id).FirstOrDefault();
            SwapValidate swVal = new SwapValidate();
            swVal.Id = sw.Id;
            swVal.MaHopDong = sw.MaHopDong;
            swVal.SdtKhachHang = sw.SdtKhachHang;
            swVal.KhuVuc = sw.KhuVuc;
            swVal.NgayTaoHD = (DateTime)sw.NgayTaoHD;
            swVal.DiaChiKH = sw.DiaChiKH;
            swVal.TenKhachHang = sw.TenKhachHang;
            swVal.MaNVTrienKhai = sw.MaNVTrienKhai;
            swVal.PhiDichVu = sw.PhiDichVu;
            return View(swVal);
        }
        [HttpPost]
        public ActionResult TrienKhaiSwap(SwapValidate swVal)
        {
            var sw = db.Swaps.Where(n => n.MaHopDong == swVal.MaHopDong).FirstOrDefault();
            var CTsw = db.ChiTietSwaps.Where(n => n.MaHopDong == swVal.MaHopDong).FirstOrDefault();
            sw.TrangThai = 3; //Hoan tat ca swap trong table Swap
            CTsw.ThoiGianHoanTat = DateTime.Now;
            CTsw.DanhGia = null;
            CTsw.TrangThai = 1; //Hoan tat ca swap trong table ChiTietSwap
            db.Swaps.Remove(sw);
            db.SaveChanges();
            return Redirect("/NhanVien/NhanCaSwap/" + Session["MaNhanVien"]);
        }
    }   //end lass
}
