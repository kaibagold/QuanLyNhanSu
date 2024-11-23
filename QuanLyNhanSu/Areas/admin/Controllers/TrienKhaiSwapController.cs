using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using System.Web.Security;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class TrienKhaiSwapController : Controller
    {
        // GET: admin/TrienKhaiSwap
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        public ActionResult Index()
        {
            var ca = db.Swaps.ToList();
            return View(ca);
        }

        [HttpGet]
        public ActionResult CreateSwap()
        {
            var chucvu = db.ChucVuNhanViens.ToList();
            var phongban = db.PhongBans.ToList();
            var hopdong = db.HopDongs.ToList();
            var chuyennganh = db.ChuyenNganhs.ToList();
            var trinhdo = db.TrinhDoHocVans.ToList();
            List<ChucVuNhanVien> list = chucvu;

            return View(new SwapValidate());
        }


        [HttpPost]
        public ActionResult CreateSwap(SwapValidate sw)
        {

            if (ModelState.IsValid)
            {
                ViewBag.err = String.Empty;
                var checkMaHopDong = db.Swaps.Any(x => x.MaHopDong == sw.MaHopDong);

                if (checkMaHopDong)
                {
                    ViewBag.err = "hợp đồng đã tồn tại";
                    //ModelState.AddModelError("MaNhanVien", "Mã tài khoản đã tồn tại");
                    return View(sw);
                }
                else
                {
                    Swap swAdd = new Swap();
                    swAdd.MaHopDong = sw.MaHopDong;
                    swAdd.TenKhachHang = sw.TenKhachHang;
                    swAdd.SdtKhachHang = sw.SdtKhachHang;
                    swAdd.DiaChiKH = sw.DiaChiKH;
                    swAdd.KhuVuc = sw.KhuVuc;
                    swAdd.MaNVLenPhieu = (string)Session["MaNhanVien"]; 
                    swAdd.MaNVTrienKhai = sw.MaNVTrienKhai;
                    swAdd.SdtSale = Convert.ToInt32(sw.SdtSale);
                    swAdd.SaleNote = sw.SaleNote;
                    swAdd.PhiDichVu = sw.PhiDichVu;
                    swAdd.NgayTaoHD = DateTime.Now;
                    swAdd.TrangThai = 0;
                    db.Swaps.Add(swAdd);
                    db.SaveChanges();
                    //xác thực tài khoản trong ứng dụng
                    //FormsAuthentication.SetAuthCookie(nvAdd.MaNhanVien, false);
                    //trả về trang quản lý
                    return Redirect("/admin/TrienKhaiSwap/index");
                }
            }
            else
            {
                return View(sw);
            }
        }//end add nhan vien
    }
}