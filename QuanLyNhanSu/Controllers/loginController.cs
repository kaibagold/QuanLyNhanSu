using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.Security;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Globalization;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;
using DocumentFormat.OpenXml.Bibliography;

namespace QuanLyNhanSu.Controllers
{
    public class loginController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        //
        // GET: /login/
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.err = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(NhanVien user)
        {

            //check email da ton tai chua
            Console.WriteLine(user);
            var checkaccount = db.NhanViens.Any(x => x.MaNhanVien == user.MaNhanVien &&
                x.MatKhau == user.MatKhau && x.TrangThai == true);
            Console.WriteLine(checkaccount);
            var checkadmin = db.NhanViens.Any(x => x.MaNhanVien == user.MaNhanVien &&
                    x.MaNhanVien == "admin" &&
                    x.MatKhau == user.MatKhau
                );

            if (checkaccount)
            {
                ViewBag.err = "";
                Session["MaNhanVien"] = user.MaNhanVien;
                var nhanvien = db.NhanViens.SingleOrDefault(n => n.MaNhanVien == user.MaNhanVien);
                Session["AvtNhanVien"] = nhanvien.HinhAnh;
                Session["TenNhanVien"] = nhanvien.HoTen;

                if (nhanvien.NgaySinh != null)
                {
                    DateTime date = (DateTime)nhanvien.NgaySinh;
                    Session["NgaySinh"] = date.ToString("dd/MM/yyyy");
                }

                Session["PhongBan"] = nhanvien.MaPhongBan;
                FormsAuthentication.SetAuthCookie(user.MaNhanVien, false);
                if (checkadmin)
                {
                    return Redirect("~/admin/Admin/Index");
                }
                else
                {
                    return Redirect("/");
                }
            }

            else
            {
                Session["user"] = null;
                ViewBag.err = "Tài khoản hoặc mật khẩu không đúng";
                //  ModelState.AddModelError("Account", "Tài khoản hoặc mật khẩu không đúng...!");
                return View();
            }

        }

        [HttpGet]
        public ActionResult UpDateUser()
        {
            UserValidate up = new UserValidate();
            var id = Session["MaNhanVien"] as String;
            var us = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();
            if (us != null)
            {
                up.MaNhanVien = us.MaNhanVien;
                up.Email = us.Email;
                up.HinhAnh = us.HinhAnh;
                //kiem tra trong thu muc du an co hinh anh nay chua ?
                bool fileExists = System.IO.File.Exists(Server.MapPath($"~/Content/anh/img_avt/{us.HinhAnh}"));
                ViewBag.FileExists = fileExists;
                up.MatKhau = us.MatKhau;
                up.XacNhanMatKhau = us.MatKhau;
                up.HoTen = us.HoTen;
                up.NgaySinh = us.NgaySinh;
                up.QueQuan = us.QueQuan;
                up.GioiTinh = us.GioiTinh;
                up.DanToc = us.DanToc;
                up.sdt_NhanVien = us.sdt_NhanVien;
                up.MaChuyenNganh = us.MaChuyenNganh;
                up.MaTrinhDoHocVan = us.MaTrinhDoHocVan;
                up.CMND = us.CMND;

                return View(up);
            }
            return Redirect("~/");
        }
        [HttpPost]
        public ActionResult UpDateUser(UserValidate us, HttpPostedFileBase HinhAnh)
        {
            try
            {
                var up = db.NhanViens.Where(n => n.MaNhanVien == us.MaNhanVien).FirstOrDefault();
                up.MaNhanVien = us.MaNhanVien;
                up.MatKhau = us.MatKhau;
                up.MatKhau = us.XacNhanMatKhau;
                up.HoTen = us.HoTen;
                up.NgaySinh = us.NgaySinh;
                up.QueQuan = us.QueQuan;
                up.GioiTinh = us.GioiTinh;
                up.DanToc = us.DanToc;
                up.sdt_NhanVien = us.sdt_NhanVien;
                //up.MaChuyenNganh = us.MaChuyenNganh;
                up.CMND = us.CMND;
                if (us.HinhAnh != null)
                {
                    HinhAnh.SaveAs(HttpContext.Server.MapPath("~/Content/anh/img_avt/") + HinhAnh.FileName);
                    up.HinhAnh = HinhAnh.FileName;
                    us.HinhAnh = HinhAnh.FileName;
                }
                else
                {
                    if (System.IO.File.Exists(Server.MapPath($"{up.HinhAnh}")))//Nếu nv có hình ảnh rồi
                        us.HinhAnh = up.HinhAnh;
                    else
                        us.HinhAnh = "avt_profile_default.png";
                }
                us.Email = up.Email;//load lại email cũ
                us.MaNhanVien = up.MaNhanVien;//load lại email cũ
                db.SaveChanges();
                TempData["SuccessMessage"] = "Cập nhật thành công!";
                Session["AvtNhanVien"] = us.HinhAnh;
                return View(us);
            }
            catch (Exception e)
            {
                TempData["SuccessMessage"] = "Cập nhật thất bại!" + e;
                return View(us);
            }
        }
        public ActionResult DangXuat()
        {
            //Đăng xuất khỏi ứng dụng
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            //Về trang chủ
            return Redirect("/");
        }
        public ActionResult LichSuLuong()
        {
            var id = Session["MaNhanVien"] as String;
            var ctL = db.ChiTietLuongs.Where(n => n.MaNhanVien == id).ToList();
        
            return View(ctL);
        }
        public static string FormatPeriodString(string input)
        {
            try
            {
                // Loại bỏ ký tự 't' và 'n'
                string formatted = input.ToLower()
                    .Replace("t", "")
                    .Replace("n", "/");

                return formatted;
            }
            catch
            {
                return input; // Trả về chuỗi gốc nếu có lỗi
            }
        }
        public ActionResult XuatFileLuong()
        {
            var id = Session["MaNhanVien"] as string;
            var ds = db.ChiTietLuongs.Where(n => n.MaNhanVien == id).ToList();
            //===================================================
            DataTable dt = new DataTable();
            //Add Datacolumn
            DataColumn workCol = dt.Columns.Add("Tháng", typeof(String));
            dt.Columns.Add("Lương cơ bản", typeof(String));
            dt.Columns.Add("BHXH", typeof(String));
            dt.Columns.Add("Phụ cấp", typeof(String));
            dt.Columns.Add("Thuế thu nhập", typeof(String));
            dt.Columns.Add("Ngày nhận lương", typeof(String));
            dt.Columns.Add("Thực lãnh", typeof(String));

            //Add in the datarow


            foreach (var item in ds)
            {
                DataRow newRow = dt.NewRow();
                newRow["Tháng"] = item.MaChiTietBangLuong;
                newRow["Lương cơ bản"] = item.LuongCoBan;
                newRow["BHXH"] = item.BHXH;
                newRow["Phụ cấp"] = item.PhuCap;
                newRow["Thuế thu nhập"] = item.ThueThuNhap;
                newRow["Ngày nhận lương"] = item.NgayNhanLuong;
                newRow["Thực lãnh"] = item.TongTienLuong;


                dt.Rows.Add(newRow);
            }

            //====================================================
            var gv = new GridView();
            //gv.DataSource = ds;
            gv.DataSource = dt;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            string fileName = "lich-su-nhan-luong-" + id + ".xls";
            Response.AddHeader("content-disposition", $"attachment; filename={fileName}");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);
            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return Redirect("/login/LichSuLuong");
        }
        public ActionResult LuongSwap(String month)
        {
            var id = Session["MaNhanVien"] as String;
            if (month == null) //Neu nguoi dung chua chon thang
            {
                var ctW = db.ChiTietSwaps.Where(n => n.MaNVTrienKhai == id && n.TrangThai == 1).ToList();
                return View(ctW);
            }
            var selectedMonth = Convert.ToInt32(month);
            Session["selectedMonth"] = month;
            var ctWW = db.ChiTietSwaps.Where(n => n.ThoiGianHoanTat.Value.Month == selectedMonth
                        && n.MaNVTrienKhai == id && n.TrangThai == 1).ToList();
            return View(ctWW);
        }
        public ActionResult QuenMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult QuenMatKhau(NhanVien user)
        {
            //check email va MaNhanVien da ton tai chua
            Console.WriteLine(user);
            var checkaccount = db.NhanViens.Any(x => x.MaNhanVien == user.MaNhanVien &&
                x.Email == user.MatKhau && x.TrangThai == true);
            Console.WriteLine(checkaccount);

            if (checkaccount)
            {
                var tb = new ThongBao();
                tb.LoaiThongBao = "quenmatkhau";
                tb.TieuDe = "quên mật khẩu";
                tb.MaNVGuiTB = user.MaNhanVien;
                tb.ThoiGianGuiTB = DateTime.Now;
                tb.MaNVNhanTB = "admin";
                tb.TrangThai = 0;
                db.ThongBaos.Add(tb);
                db.SaveChanges();
                ViewBag.err = "Đã yêu cầu, vui lòng kiểm tra Email";
                return View();
            }

            else
            {
                ViewBag.err = "Thông tin không hợp lệ";
                return View();
            }

        }
    }
}