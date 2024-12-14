using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Vml;
using QuanLyNhanSu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace QuanLyNhanSu.Areas.admin.Controllers
{
    public class ThongBaoController : Controller
    {
        QuanLyNhanSuEntities db = new QuanLyNhanSuEntities();
        // GET: admin/ThongBao
        public ActionResult Index()
        {
            var tb = db.ThongBaos.Where(n => n.MaNVNhanTB == "admin").OrderByDescending(n=>n.Id).ToList();
            return View(tb);
        }
        public ActionResult ChiTietPhieuNhap(int id)
        {
            var tb = db.ThongBaos.Where(n => n.Id == id).FirstOrDefault();
            if(tb.TrangThai==0)
            {
                tb.TrangThai = 1;
            }    
            db.SaveChanges();
            return View(tb);
        }
        public class VatTus
        {
            public string MaVatTu { get; set; }
            public int SoLuong { get; set; }
        }
        [HttpPost]
        public ActionResult DuyetPhieuNhap(List<VatTus> dsVatTu,string MaNhanVien,int MaPhieu)
        {
            VatTuCaNhan vatTuCaNhan = new VatTuCaNhan();
            var vatTu = db.VatTus.ToList();
            if(dsVatTu.Count > 0)
            {
                //thêm vật tư cá nhân
                foreach (var item in dsVatTu)
                {
                    if(item.MaVatTu != null && item.SoLuong > 0) 
                    {
                        int slTon = vatTu.Where(n => n.MaVatTu == item.MaVatTu).Select(n => n.SoLuong).FirstOrDefault();
                        var vatTuUpdate = vatTu.Where(n => n.MaVatTu == item.MaVatTu).FirstOrDefault();
                        bool exists = db.VatTuCaNhans.Any(nv => nv.MaVatTu == item.MaVatTu && nv.MaNhanVien == MaNhanVien);
                        if (slTon >= item.SoLuong)//kiểm tra số lượng tồn còn đủ để xuất hay không
                        {
                            if(exists)//nếu nhân viên chưa có vật tư trong kho thì thêm mới, ngược lại thì update sl vật tư đó
                            {
                                var vatTuCaNhanUpdate = db.VatTuCaNhans.Where(n => n.MaNhanVien == MaNhanVien && n.MaVatTu == item.MaVatTu).FirstOrDefault();
                                vatTuCaNhanUpdate.SoLuong += item.SoLuong;
                            }
                            else
                            {
                                vatTuCaNhan.MaNhanVien = MaNhanVien;
                                vatTuCaNhan.MaVatTu = item.MaVatTu;
                                vatTuCaNhan.SoLuong = item.SoLuong;
                                vatTuCaNhan.TinhTrang = 1;
                                db.VatTuCaNhans.Add(vatTuCaNhan);
                            }
                            //Cập nhật vật tư trong kho
                            vatTuUpdate.SoLuong -= item.SoLuong;
                        }
                        else
                            return Json(new { success = false, message = "số lượng tồn không đủ!" });
                        db.SaveChanges();
                    }    
                }
                //duyệt thông báo và phiếu nhập
                var tb = db.ThongBaos.Where(n => n.MaPhieu == MaPhieu).FirstOrDefault();
                tb.TrangThai = 2;
                tb.ThoiGianDuyetTB = DateTime.Now;
                var phieunhap = db.PhieuNhaps.Where(n => n.Id == MaPhieu).FirstOrDefault();
                phieunhap.MaNVDuyetPhieu = "admin";
                phieunhap.ThoiGianDuyetPhieu = DateTime.Now;
                phieunhap.TrangThai = 1; //Đã duyệt đơn xuất vật tư
                //tạo thông báo đã duyệt phiếu vật tư đến nhân viên
                var tbao = new ThongBao();
                tbao.LoaiThongBao = "nhanvattu";
                tbao.TieuDe = "nhận vật tư";
                tbao.MaNVGuiTB = "admin";
                tbao.ThoiGianGuiTB = DateTime.Now;
                tbao.MaNVNhanTB = MaNhanVien;
                tbao.TrangThai = 0;
                db.ThongBaos.Add(tbao);
                db.SaveChanges();
                return Json(new { success = true, message = "Đã duyệt thành công!" });
            }
            return Json(new { success = false, message = "Có lỗi!" });
        } 
        public static string GetTimeSinceNotification(DateTime notificationTime)
        {
            // Lấy thời gian hiện tại
            DateTime currentTime = DateTime.Now;

            // Tính khoảng thời gian đã trôi qua
            TimeSpan timeElapsed = currentTime - notificationTime;

            // Kiểm tra xem thời gian đã trôi qua có âm không
            if (timeElapsed.TotalSeconds <= 0)
            {
                return "vài giây trước.";
            }

            // Tạo chuỗi kết quả
            string result = "";
            // Thêm ngày
            if (timeElapsed.Days > 0)
            {
                result += $"{timeElapsed.Days} ngày ";
            }
            else
            {
                // Thêm giờ
                if (timeElapsed.Hours > 0)
                {
                    result += $"{timeElapsed.Hours} giờ ";
                }

                // Thêm phút
                if (timeElapsed.Minutes > 0)
                {
                    result += $"{timeElapsed.Minutes} phút ";
                }
            }
            
            // Thêm từ "trước" vào cuối
            result += "trước";

            return result.Trim(); // Trim để loại bỏ khoảng trắng thừa
        }
        public async Task<ActionResult> CapLaiMatKhau(int id)
        {
            var tb = db.ThongBaos.Where(n => n.Id == id).FirstOrDefault();
            if (tb.TrangThai == 2)
            {
                TempData["ThongBao"] = "Yêu cầu đã được xử lí trước đó";
                return Redirect("~/admin/ThongBao");
            }
            // Truy vấn record từ bảng ThongBaos
            var thongBao = await db.ThongBaos.FindAsync(id);
            if (thongBao == null)
            {
                return HttpNotFound("Không tìm thấy thông báo.");
            }

            var MaNV = db.ThongBaos.Where(n=>n.Id==id).FirstOrDefault().MaNVGuiTB; // Giả sử bạn có thuộc tính Email trong ThongBaos
            var email = db.NhanViens.Where(n => n.MaNhanVien == MaNV).FirstOrDefault().Email;
            // Tạo mật khẩu ngẫu nhiên
            var newPassword = GenerateRandomPassword();
            // Gửi email với mật khẩu mới
            await SendEmailAsync(email, newPassword);
            tb.ThoiGianDuyetTB = DateTime.Now;
            tb.TrangThai = 2;
            var nv = db.NhanViens.Where(n => n.MaNhanVien == tb.MaNVGuiTB).FirstOrDefault();
            nv.MatKhau = newPassword;
            var tbAdd = new ThongBao();//tạo thông báo đã cấp lại mật khẩu gửi đến nv
            tbAdd.LoaiThongBao = "capmatkhau";
            tbAdd.TieuDe = "cấp lại mật khẩu";
            tbAdd.MaNVGuiTB = "admin";
            tbAdd.ThoiGianGuiTB = DateTime.Now;
            tbAdd.MaNVNhanTB = tb.MaNVGuiTB;
            tbAdd.TrangThai = 0;
            db.ThongBaos.Add(tbAdd);
            db.SaveChanges();
            // Trả về thông báo thành công
            TempData["ThongBao"] = "Xử lí thành công";
            return Redirect("~/admin/ThongBao");
        }

        private string GenerateRandomPassword(int length = 8)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var random = new Random();
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = validChars[random.Next(validChars.Length)];
            }
            return new string(result);
        }

        private async Task SendEmailAsync(string email, string newPassword)
        {
            var fromAddress = new MailAddress("tranhuyeakar2002@gmail.com", "Admin"); // Địa chỉ email gửi
            var toAddress = new MailAddress(email);
            const string fromPassword = "vszrlbrnzapfdvro"; // Mật khẩu email gửi
            const string subject = "Cấp lại mật khẩu mới";
            string body = $"Mật khẩu mới của bạn là: {newPassword}";
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com", // Địa chỉ máy chủ SMTP
                Port = 587, // Cổng SMTP
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                await smtp.SendMailAsync(message);
            }
        }
        private void SendEmailAsyn(string email, string newPassword)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress("tranhuyeakar2002@gmail.com");
            mail.To.Add("tranhiepeakar@gmail.com");
            mail.Subject = "Test Email Subject";
            mail.Body = "This is the body of a test email sent from an ASP.NET MVC application.";
            mail.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("tranhuyeakar2028@gmail.com", "vszrlbrnzapfdvro");
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);
        }
    }
}