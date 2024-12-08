using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.Security;
using Microsoft.AspNet.SignalR;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class AdminController : AuthorController
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();

        //
        // GET: /admin/Admin/
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return Redirect("/");
        }
        public int GetNotificationCount()
        {
            // Truy vấn số lượng thông báo chưa đọc từ bảng ThongBaos
            var count = db.ThongBaos.Where(n=>n.MaNVNhanTB == "admin" && n.TrangThai == 0).Count();
            // Gửi số lượng thông báo đến client
            var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.updateNotificationCount(count);
            return count;
        }
    }
}