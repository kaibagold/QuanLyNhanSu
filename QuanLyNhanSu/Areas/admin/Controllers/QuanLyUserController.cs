using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNhanSu.Models;
using System.Web.Security;
//using cExcel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class QuanLyUserController : AuthorController
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        //
        // GET: /admin/QuanLyUser/
        public ActionResult Index()
        {
            var user = db.NhanViens.Where(x => x.MaNhanVien != "admin").ToList();
            return View(user);
        }
        [HttpGet]
        public ActionResult DetailUser(String id)
        {
            UserValidate up = new UserValidate();
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
                up.MaPhongBan = us.MaPhongBan;
                up.MaChucVuNV = us.MaChucVuNV;
                return View(up);
            }
            return Redirect("~/");
        }
        [HttpPost]
        public ActionResult DetailUser(UserValidate us, HttpPostedFileBase HinhAnh)
        {
            //if (ModelState.IsValid)

            try
            {
                var up = db.NhanViens.Where(n => n.MaNhanVien == us.MaNhanVien).FirstOrDefault();
                up.MaNhanVien = us.MaNhanVien;
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
                        us.HinhAnh = up.HinhAnh;
                }
                us.Email = up.Email;//load lại email cũ
                us.MaNhanVien = up.MaNhanVien;//load lại email cũ
                db.SaveChanges();
                TempData["SuccessMessage"] = "Cập nhật thành công!";
                return View(us);
            }
            catch (Exception e)
            {
                TempData["SuccessMessage"] = "Cập nhật thất bại! "+e;
                return View(us);
            }
        }

        [HttpPost]
        public ActionResult FetchChucVu(string ma)
        {
            var result = db.ChucVuNhanViens.Where(x => x.MaPhongBan == ma)
                .Select(x => new
                {
                    MaCV = x.MaChucVuNV,
                    TenCV = x.TenChucVu
                }).ToList();
            return Json(result);
        }

        public ActionResult XoaUser(String id)
        {

            var a = db.NhanViens.Where(x => x.MaNhanVien == id).SingleOrDefault();
            var hd = db.HopDongs.Where(x => x.MaHopDong == id).SingleOrDefault();
            var luong = db.Luongs.Where(x => x.MaNhanVien == id).SingleOrDefault();
            var ctLuong = db.ChiTietLuongs.Where(x => x.MaNhanVien == id).ToList();
            foreach (var item in ctLuong)
            {
                db.ChiTietLuongs.Remove(item);
            }
            db.Luongs.Remove(luong);
            db.NhanViens.Remove(a);
            db.HopDongs.Remove(hd);

            db.SaveChanges();
            return Redirect("~/admin/QuanLyUser");
        }
        [HttpGet]
        public ActionResult UpdateUser(String id)
        {
            var user = db.NhanViens.Where(n => n.MaNhanVien == id).FirstOrDefault();
            UserValidate userVal = new UserValidate();

            userVal.MaNhanVien = user.MaNhanVien;
            userVal.HoTen = user.HoTen;
            userVal.MatKhau = user.MatKhau;
            userVal.GioiTinh = user.GioiTinh;

            userVal.MaChucVuNV = user.MaChucVuNV;
            userVal.QueQuan = user.QueQuan;
            userVal.HinhAnh = user.HinhAnh;
            userVal.DanToc = user.DanToc;
            userVal.sdt_NhanVien = user.sdt_NhanVien;
            userVal.MaHopDong = user.MaHopDong;

            userVal.NgaySinh = user.NgaySinh;
            userVal.TrangThai = user.TrangThai;
            userVal.MaChuyenNganh = user.MaChuyenNganh;
            userVal.MaTrinhDoHocVan = user.MaTrinhDoHocVan;
            userVal.MaPhongBan = user.MaPhongBan;

            userVal.CMND = user.CMND;
            userVal.XacNhanMatKhau = user.MatKhau;

            return View(userVal);
            //  return View(user);
        }
        [HttpPost]
        public ActionResult UpdateUser(UserValidate upUser)
        {
            upUser.XacNhanMatKhau = upUser.MatKhau;
            var us = db.NhanViens.Where(n => n.MaNhanVien == upUser.MaNhanVien).FirstOrDefault();


                if (us != null)
                {

                    CapNhatTrinhDoHocVan capNhat = new CapNhatTrinhDoHocVan();
                    capNhat.MaNhanVien = upUser.MaNhanVien;
                    capNhat.NgayCapNhat = DateTime.Now.Date;
                    capNhat.MaTrinhDoTruoc = us.MaTrinhDoHocVan;
                    capNhat.MaTrinhDoCapNhat = upUser.MaTrinhDoHocVan;

                    us.MaNhanVien = upUser.MaNhanVien;
                    us.HoTen = upUser.HoTen;
                    us.MatKhau = upUser.MatKhau;
                    us.GioiTinh = upUser.GioiTinh;

                    us.MaChucVuNV = upUser.MaChucVuNV;
                    us.QueQuan = upUser.QueQuan;
                    us.HinhAnh = upUser.HinhAnh;
                    us.DanToc = upUser.DanToc;
                    us.sdt_NhanVien = upUser.sdt_NhanVien;
                    us.MaHopDong = upUser.MaHopDong;

                    us.NgaySinh = upUser.NgaySinh;
                    us.TrangThai = upUser.TrangThai;
                    us.MaChuyenNganh = upUser.MaChuyenNganh;
                    us.MaTrinhDoHocVan = upUser.MaTrinhDoHocVan;
                    us.MaPhongBan = upUser.MaPhongBan;
                    us.CMND = upUser.CMND;                 

                    db.CapNhatTrinhDoHocVans.Add(capNhat);

                    db.SaveChanges();
                    return Redirect("/admin/QuanLyUser");

                }

            return View(upUser);

        }//end update

        [HttpGet]

        public ActionResult ThemUser()
        {
            var chucvu = db.ChucVuNhanViens.ToList();
            var phongban = db.PhongBans.ToList();
            var hopdong = db.HopDongs.ToList();
            var chuyennganh = db.ChuyenNganhs.ToList();
            var trinhdo = db.TrinhDoHocVans.ToList();
            List<ChucVuNhanVien> list = chucvu;

            return View(new UserValidate());
        }


        [HttpPost]
        public ActionResult ThemUser(UserValidate nv)
        {
            nv.XacNhanMatKhau = nv.MatKhau;
            if (ModelState.IsValid)
            {
                ViewBag.err = String.Empty;
                var checkMaNhanVien = db.NhanViens.Any(x => x.MaNhanVien == nv.MaNhanVien);

                if (checkMaNhanVien)
                {
                    ViewBag.err = "tài khoản đã tồn tại";
                    //ModelState.AddModelError("MaNhanVien", "Mã tài khoản đã tồn tại");
                    return View(nv);
                }
                else
                {
                    Luong luong = new Luong();
                    HopDong hd = new HopDong();
                    NhanVien nvAdd = new NhanVien();
                    nvAdd.MaNhanVien = nv.MaNhanVien;
                    nvAdd.Email = nv.Email;
                    nvAdd.MatKhau = nv.MatKhau;
                    nvAdd.HoTen = nv.HoTen;
                    nvAdd.NgaySinh = nv.NgaySinh;
                    nvAdd.QueQuan = nv.QueQuan;
                    nvAdd.GioiTinh = nv.GioiTinh;
                    nvAdd.DanToc = nv.DanToc;
                    nvAdd.MaChucVuNV = nv.MaChucVuNV;
                    nvAdd.MaPhongBan = nv.MaPhongBan;
                    nvAdd.MaChuyenNganh = nv.MaChuyenNganh;
                    nvAdd.MaTrinhDoHocVan = nv.MaTrinhDoHocVan;
                    nvAdd.MaHopDong = nv.MaNhanVien;
                    nvAdd.TrangThai = true;
                    nvAdd.HinhAnh = "icon.jpg";

                    //add hop dong
                    hd.MaHopDong = nv.MaNhanVien;
                    hd.NgayBatDau = DateTime.Now.Date;

                    //tao bang luong
                    luong.MaNhanVien = nv.MaNhanVien;
                    luong.LuongToiThieu = 6000000;
                    luong.BHXH = 0.08;
                    luong.BHYT = 0.015;
                    luong.BHTN = 0.01;
                    var trinhdo = db.TrinhDoHocVans.Where(n => n.MaTrinhDoHocVan.Equals(nv.MaTrinhDoHocVan)).FirstOrDefault();
                    var chucvu = db.ChucVuNhanViens.Where(n => n.MaChucVuNV.Equals(nv.MaChucVuNV)).SingleOrDefault();

                    if (trinhdo.MaTrinhDoHocVan.Equals(nv.MaTrinhDoHocVan))
                    {
                        luong.HeSoLuong = (double)trinhdo.HeSoBac;
                    }


                    if (chucvu.MaChucVuNV.Equals(nv.MaChucVuNV))
                    {
                        if (chucvu.HSPC != null)
                        {
                            luong.PhuCap = (double)chucvu.HSPC;
                        }
                        else
                        { luong.PhuCap = 0; }
                    }



                    // tmp.Image = "~/Content/images/icon.jpg";
                    db.NhanViens.Add(nvAdd);
                    db.HopDongs.Add(hd);

                    db.Luongs.Add(luong);
                    // @ViewBag.add = "Đăng ký thành công";
                    db.SaveChanges();
                    //xác thực tài khoản trong ứng dụng
                    FormsAuthentication.SetAuthCookie(nvAdd.MaNhanVien, false);
                    //trả về trang quản lý

                    return Redirect("/admin/QuanLyUser");
                }
            }
            else
            {

                return View(nv);
            }
        }//end add nhan vien

        public ActionResult QuaTrinhCongTac(String id)
        {
            var ds = db.LuanChuyenNhanViens.Where(n => n.MaNhanVien == id).ToList();
            return View(ds);
        }

        public ActionResult XuatFileExel()
        {

            var ds = db.NhanViens.Where(n => n.MaNhanVien != "admin" && n.MaHopDong != null).ToList();
            var phong = db.PhongBans.ToList();
            var gv = new GridView();
            //===================================================
            DataTable dt = new DataTable();
            //Add Datacolumn
            DataColumn workCol = dt.Columns.Add("Họ tên", typeof(String));

            dt.Columns.Add("Phòng ban", typeof(String));
            dt.Columns.Add("Chức vụ", typeof(String));
            dt.Columns.Add("Học vấn", typeof(String));
            dt.Columns.Add("Chuyên ngành", typeof(String));

            //Add in the datarow


            foreach (var item in ds)
            {
                DataRow newRow = dt.NewRow();
                newRow["Họ tên"] = item.HoTen;
                newRow["Phòng ban"] = item.PhongBan.TenPhongBan;
                newRow["Chức vụ"] = item.ChucVuNhanVien.TenChucVu;
                newRow["Học vấn"] = item.TrinhDoHocVan.TenTrinhDo;
                newRow["Chuyên ngành"] = item.ChuyenNganh.TenChuyenNganh;

                dt.Rows.Add(newRow);
            }

            //====================================================
            gv.DataSource = dt;
            // gv.DataSource = ds;
            gv.DataBind();

            Response.ClearContent();
            Response.Buffer = true;

            Response.AddHeader("content-disposition", "attachment; filename=danh-sach.xls");
            Response.ContentType = "application/ms-excel";

            Response.Charset = "";
            StringWriter objStringWriter = new StringWriter();
            HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(objStringWriter);

            gv.RenderControl(objHtmlTextWriter);

            Response.Output.Write(objStringWriter.ToString());
            Response.Flush();
            Response.End();
            return Redirect("/admin/QuanLyUser");
        }

        public ActionResult QuaTrinhHoc(String id)
        {
            var ht = db.CapNhatTrinhDoHocVans.Where(n => n.MaNhanVien == id).ToList();
            return View(ht);
        }

        // Action cập nhật trạng thái
        [HttpPost]
        public ActionResult CapNhatTrangThai(string id)
        {
            // Tìm user theo ID
            var user = db.NhanViens.FirstOrDefault(u => u.MaNhanVien == id);
            if (user == null)
            {
                return Redirect("/admin/QuanLyUser"); // Trả về 404 nếu không tìm thấy user
            }

            // Đảo trạng thái
            user.TrangThai = !user.TrangThai;

            // Lưu thay đổi vào database
            db.SaveChanges();

            // Trả về JSON hoặc Redirect đến view gốc
            return Json(new { success = true, status = user.TrangThai });
        }
    }   //end lass
}