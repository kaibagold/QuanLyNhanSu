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
    }
}