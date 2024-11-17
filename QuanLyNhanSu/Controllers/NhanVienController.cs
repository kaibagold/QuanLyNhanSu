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
    }
}