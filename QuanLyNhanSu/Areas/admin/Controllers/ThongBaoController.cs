using DocumentFormat.OpenXml.Office2010.Excel;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class ThongBaoController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        // GET: admin/ThongBao
        public ActionResult Index()
        {
            var tb = db.ThongBaos.Where(n => n.MaNVNhanTB == "admin").ToList();
            return View(tb);
        }
        public ActionResult ChiTietPhieuNhap(int id)
        {
            var tb = db.ThongBaos.Where(n => n.Id == id).FirstOrDefault();
            if(tb.TrangThai==0)
            {
                tb.TrangThai = 1;
            }    
            db.SaveChanges();
            return View(tb);
        }
        public class VatTus
        {
            public string MaVatTu { get; set; }
            public int SoLuong { get; set; }
        }
        [HttpPost]
        public ActionResult DuyetPhieuNhap(List<VatTus> dsVatTu,string MaNhanVien,int MaPhieu)
        {
            VatTuCaNhan vatTuCaNhan = new VatTuCaNhan();
            var vatTu = db.VatTus.ToList();
            if(dsVatTu.Count > 0)
            {
                //thêm vật tư cá nhân
                foreach (var item in dsVatTu)
                {
                    if(item.MaVatTu != null && item.SoLuong > 0) 
                    {
                        int slTon = vatTu.Where(n => n.MaVatTu == item.MaVatTu).Select(n => n.SoLuong).FirstOrDefault();
                        var vatTuUpdate = vatTu.Where(n => n.MaVatTu == item.MaVatTu).FirstOrDefault();
                        bool exists = db.VatTuCaNhans.Any(nv => nv.MaVatTu == item.MaVatTu);
                        bool exists1 = db.NhanViens.Any(nv => nv.MaNhanVien == MaNhanVien);
                        if (slTon >= item.SoLuong)//kiểm tra số lượng tồn còn đủ để xuất hay không
                        {
                            if(!exists && !exists1)//nếu nhân viên chưa có vật tư trong kho thì thêm mới, ngược lại thì update sl vật tư đó
                            {
                                vatTuCaNhan.MaNhanVien = MaNhanVien;
                                vatTuCaNhan.MaVatTu = item.MaVatTu;
                                vatTuCaNhan.SoLuong = item.SoLuong;
                                vatTuCaNhan.TinhTrang = 0;
                                db.VatTuCaNhans.Add(vatTuCaNhan);
                            }
                            else
                            {
                                var vatTuCaNhanUpdate = db.VatTuCaNhans.Where(n => n.MaNhanVien == MaNhanVien && n.MaVatTu == item.MaVatTu).FirstOrDefault();
                                vatTuCaNhanUpdate.SoLuong += item.SoLuong;
                            }
                            //Cập nhật vật tư trong kho
                            vatTuUpdate.SoLuong -= item.SoLuong;
                        }
                        else
                            return Json(new { success = false, message = "số lượng tồn không đủ!" });
                        db.SaveChanges();
                    }    
                }
                //duyệt thông báo và phiếu nhập
                var tb = db.ThongBaos.Where(n => n.MaPhieu == MaPhieu).FirstOrDefault();
                tb.TrangThai = 2;
                tb.ThoiGianDuyetTB = DateTime.Now;
                var phieunhap = db.PhieuNhaps.Where(n => n.Id == MaPhieu).FirstOrDefault();
                phieunhap.MaNVDuyetPhieu = "admin";
                phieunhap.ThoiGianDuyetPhieu = DateTime.Now;
                phieunhap.TrangThai = 1; //Đã duyệt đơn xuất vật tư
                db.SaveChanges();
                return Json(new { success = true, message = "Đã duyệt thành công!" });
            }
            return Json(new { success = false, message = "Có lỗi!" });
        }
        public ActionResult DuyetPhieuNhapp(int id)
        {
            var tb = db.ThongBaos.Where(n => n.MaPhieu == id).FirstOrDefault();
            tb.TrangThai = 2;
            tb.ThoiGianDuyetTB = DateTime.Now;
            var phieunhap = db.PhieuNhaps.Where(n => n.Id == id).FirstOrDefault();
            phieunhap.MaNVDuyetPhieu = "admin";
            phieunhap.ThoiGianDuyetPhieu = DateTime.Now;
            phieunhap.TrangThai = 1; //Đã duyệt đơn xuất vật tư
            db.SaveChanges();
            return Redirect("~/admin/ThongBao");
        }
        public static string GetTimeSinceNotification(DateTime notificationTime)
        {
            // Lấy thời gian hiện tại
            DateTime currentTime = DateTime.Now;

            // Tính khoảng thời gian đã trôi qua
            TimeSpan timeElapsed = currentTime - notificationTime;

            // Kiểm tra xem thời gian đã trôi qua có âm không
            if (timeElapsed.TotalSeconds < 0)
            {
                return "Thời gian thông báo chưa đến.";
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