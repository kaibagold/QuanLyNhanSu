using DocumentFormat.OpenXml.Office2010.Excel;
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
                    if (sw.MaNVTrienKhai != "")
                        swAdd.MaNVTrienKhai = sw.MaNVTrienKhai;
                    swAdd.SdtSale = Convert.ToInt32(sw.SdtSale);
                    swAdd.SaleNote = sw.SaleNote;
                    swAdd.PhiDichVu = sw.PhiDichVu;
                    swAdd.NgayTaoHD = DateTime.Now;
                    if (sw.MaNVTrienKhai == null)//nếu chưa phân ca
                        swAdd.TrangThai = 0;
                    else
                        swAdd.TrangThai = 1;
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
        }
        [HttpPost]
        public JsonResult FetchNhanVienByKhuVuc(string khuVuc)
        {
            try
            {
                // Lấy danh sách nhân viên theo khu vực
                var nhanViens = db.NhanViens
                                .Where(nv => nv.MaPhongBan == "kythuat")
                            .Select(nv => new
                            {
                                MaNhanVien = nv.MaNhanVien,
                                TenNhanVien = nv.HoTen,
                                KhuVuc = nv.KhuVuc,
                                // Thêm các trường khác nếu cần
                            })
                            .OrderByDescending(nv => nv.KhuVuc == khuVuc)
                            .ThenBy(nv => nv.KhuVuc)
                            .ToList();

                return Json(nhanViens);
            }
            catch (Exception ex)
            {
                return Json(new { error = true, message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult PhanCaSwap(int id)
        {
            var sw = db.Swaps.Where(n => n.Id == id).FirstOrDefault();
            SwapValidate swVal = new SwapValidate();
            swVal.Id = sw.Id;
            swVal.MaHopDong = sw.MaHopDong;
            swVal.SdtKhachHang = sw.SdtKhachHang;
            swVal.KhuVuc = sw.KhuVuc;
            swVal.TenKhachHang = sw.TenKhachHang;
            swVal.MaNVTrienKhai = sw.MaNVTrienKhai;
            swVal.PhiDichVu = sw.PhiDichVu;
            return View(swVal);
        }
        [HttpPost]
        public ActionResult PhanCaSwap(SwapValidate swVal)
        {
            var sw = db.Swaps.Where(n => n.Id == swVal.Id).FirstOrDefault();
            ViewBag.Error = string.Empty;
            if (swVal.MaNVTrienKhai == "" || swVal.MaNVTrienKhai == null)
            {
                ViewBag.Error = "Vui lòng nhập mã nv";
                return View(swVal);
            }
            else
            {
                sw.MaNVTrienKhai = swVal.MaNVTrienKhai;
                sw.TrangThai = 1;
                db.SaveChanges();
                return Redirect("/admin/TrienKhaiSwap");
            }
        }
    }
}