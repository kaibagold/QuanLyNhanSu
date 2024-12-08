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
            tb.TrangThai = 1;
            db.SaveChanges();
            return View(tb);
        }
    }
}