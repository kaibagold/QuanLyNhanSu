using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DocumentFormat.OpenXml.Office2010.Excel;
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
            if (Session["MaNhanVien"] != null)
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
        public ActionResult TamUngVatTu()
        {
            if (Session["MaNhanVien"] == null)
            {
                return RedirectToAction("Login", "login");
            }
                db.Configuration.ProxyCreationEnabled = false; //tránh lỗi lặp truy vấn trong js
                var vattu = db.VatTus.ToList();
                return View(vattu);
        }
        public class VatTus
        {
            public int Id { get; set; }
            public int MaPhieu { get; set; }
            public string MaVatTu { get; set; }
            public int SoLuong { get; set; }
        }
        [HttpPost]
        public ActionResult TamUngVatTu(List<VatTus> dsTamUng)
        {
            if (dsTamUng == null || dsTamUng.Count == 0 )
            {
                return Json(new { success = false, message = "Mảng rỗng!" });
            }
            else
            {
                var Phieu = new PhieuNhap();
                var MaNVLenPhieu = Convert.ToString(Session["MaNhanVien"]);
                Phieu.MaNVLenPhieu = MaNVLenPhieu;
                Phieu.ThoiGianTaoPhieu = DateTime.Now;
                Phieu.TrangThai = 0;
                db.PhieuNhaps.Add(Phieu);
                db.SaveChanges();

                var ctPhieu = new ChiTietPhieuNhap();
                var latestPhieuNhap = db.PhieuNhaps.OrderByDescending(p => p.Id).FirstOrDefault();
                foreach (var vatTu in dsTamUng)
                {
                    ctPhieu.MaPhieu = latestPhieuNhap.Id;
                    ctPhieu.MaVatTu = vatTu.MaVatTu;
                    ctPhieu.SoLuong = vatTu.SoLuong;
                    db.ChiTietPhieuNhaps.Add(ctPhieu);
                    db.SaveChanges();
                }
                //Tạo thông báo đến admin
                var ThongBao = new ThongBao();
                ThongBao.LoaiThongBao = "xuatvattu";
                ThongBao.MaPhieu = latestPhieuNhap.Id;
                ThongBao.TieuDe = "xuất vật tư";
                ThongBao.MaNVGuiTB = MaNVLenPhieu;
                ThongBao.MaNVNhanTB = "admin";
                ThongBao.ThoiGianGuiTB = DateTime.Now;
                ThongBao.TrangThai = 0;
                db.ThongBaos.Add(ThongBao);
                db.SaveChanges();
                return Json(new { success = true, message = "Đã lưu thành công!" });
            }
            // Lưu dữ liệu vào database
            // _context.YourTable.AddRange(vatTus);
            // _context.SaveChanges();
        }
        [HttpGet]
        public ActionResult GetChiTietPhieuNhap(int id)
        {
            // Truy vấn dữ liệu từ bảng ChiTietPhieuNhaps theo id
            var chiTiet = db.ChiTietPhieuNhaps.Where(c => c.MaPhieu == id).ToList();
            if (chiTiet == null)
            {
                return Content("<p>Không tìm thấy dữ liệu.</p>");
            }

            // Trả về nội dung chi tiết
            string body = null;
            foreach(var item in chiTiet)
            {
                body += $"<tr><td> {item.MaVatTu}</td><td> {item.SoLuong}</td></tr>";
            }
            var content = "<div class=\"table-responsive\"><table id=\"table-taikhoan\" class=\"table table-bordered table-striped table-hover\"><thead><tr class=\"success\"> <th>Mã vật tư</th><th>Số lượng</th></tr></thead>  <tbody>" + body+"</tbody></table></div>";
            return Content(content);
        }
    }   //end lass
}
