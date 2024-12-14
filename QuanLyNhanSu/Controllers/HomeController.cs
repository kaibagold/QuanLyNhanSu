using Microsoft.AspNet.SignalR;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyNhanSu.Controllers
{
    public class HomeController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public int GetNotificationCount()
        {
            if (Session["MaNhanVien"] != null)
            { // Truy vấn số lượng thông báo chưa đọc từ bảng ThongBaos
                string MaNV= Session["MaNhanVien"].ToString();
                var count = db.ThongBaos.Where(n => n.MaNVNhanTB == MaNV && n.TrangThai == 0).Count();
                // Gửi số lượng thông báo đến client
                var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHubToUser>();
                context.Clients.All.updateNotificationCountUser(count);
                return count;
            }
            return 0;
        }
    }
}