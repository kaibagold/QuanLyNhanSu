using DocumentFormat.OpenXml.Drawing.Charts;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class QuanLyVatTuController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        // GET: admin/QuanLyVatTu
        public ActionResult Index()
        {
            var vt = db.VatTus.ToList();
            return View(vt);
        }
        // Action cập nhật trạng thái
        [HttpPost]
        public ActionResult CapNhatTrangThai(string id)
        {
            // Tìm user theo ID
            var vt = db.VatTus.FirstOrDefault(u => u.MaVatTu == id);
            if (vt == null)
            {
                return Redirect("/admin/QuanLyVatTu"); // Trả về 404 nếu không tìm thấy user
            }

            // Đảo trạng thái
            if(vt.TrangThai == 2)
                vt.TrangThai = 0;
            else
                vt.TrangThai = 2;

            // Lưu thay đổi vào database
            db.SaveChanges();

            // Trả về JSON hoặc Redirect đến view gốc
            return Json(new { success = true, status = vt.TrangThai });
        }
        [HttpGet]
        public ActionResult SuaVatTu(String id)
        {
            var vt = db.VatTus.Where(n => n.MaVatTu == id).FirstOrDefault();
            if (vt != null)
            {
                VatTu tmp = new VatTu();
                tmp.MaVatTu = vt.MaVatTu;
                tmp.TenVatTu = vt.TenVatTu;
                tmp.DonViTinh = vt.DonViTinh;
                tmp.SoLuong = vt.SoLuong;
                tmp.TrangThai = vt.TrangThai;
                return View(tmp);
            }
            else
            {
                return Redirect("/");
            }
        }
        [HttpPost]
        public ActionResult SuaVatTu(VatTu vt)
        {
            if (ModelState.IsValid)
            {
                var tmp = db.VatTus.Where(n => n.MaVatTu == vt.MaVatTu).FirstOrDefault();
                if (tmp != null)
                {
                    tmp.TenVatTu = vt.TenVatTu;
                    tmp.DonViTinh = vt.DonViTinh;
                    tmp.SoLuong = vt.SoLuong;
                    tmp.TrangThai = vt.TrangThai;
                    db.SaveChanges();
                    return Redirect("/admin/QuanLyVatTu");
                }
            }
            return View(vt);
        }//end update
        [HttpGet]
        public ActionResult ThemVatTu()
        {
            return View(new VatTu());
        }
        [HttpPost]
        public ActionResult ThemVatTu(VatTu vt)
        {
            if (ModelState.IsValid)
            {
                var checkVT = db.VatTus.Any(x => x.MaVatTu == vt.MaVatTu);

                if (checkVT == false)
                {
                    VatTu add = new VatTu();
                    add.MaVatTu = vt.MaVatTu;
                    add.TenVatTu = vt.TenVatTu;
                    add.DonViTinh = vt.DonViTinh;
                    add.SdtKhachHang = "0336978061";
                    add.SoLuong = vt.SoLuong;
                    add.TrangThai = vt.TrangThai;
                    db.VatTus.Add(add);
                    db.SaveChanges();
                    return Redirect("/admin/QuanLyVatTu");
                }
                else
                {
                    ViewBag.err = "mã vật tư đã tồn tại ";
                    return View(vt);
                }
            }
            else
            {
                return View(vt);
            }
        }//end them
        public ActionResult VatTuCaNhan()
        {
            var nv = db.NhanViens.Where(n=>n.MaPhongBan=="kythuat").ToList();
            return View(nv);
        }
        public ActionResult ChiTietVatTuCaNhan(string id)
        {
            ViewBag.MaNhanVien = id;
            var vt = db.VatTuCaNhans.Where(n => n.MaNhanVien == id).ToList();
            return View(vt);
        }
    }
}