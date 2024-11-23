using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class SwapValidate
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nhập mã hợp đồng")]
        [RegularExpression(@"[A-Za-z0-9]*$", ErrorMessage = "Tài khoản chứa kí tự đặc biệt")]
        [MaxLength(30, ErrorMessage = "Vượt quá số kí tự 30")]
        public string MaHopDong { get; set; }

        [Required(ErrorMessage = "Nhập tên khách hàng")]
        [StringLength(30)]
        public string TenKhachHang { get; set; }

        [MaxLength(11, ErrorMessage = "sdt tối đa 11 số")]
        [RegularExpression(@"[0-9]*$", ErrorMessage = "chỉ được nhập số")]
        public string SdtKhachHang { get; set; }

        [MaxLength(70, ErrorMessage = "Vượt quá số kí tự 70")]
        public string DiaChiKH { get; set; }

        [Required(ErrorMessage = "Chọn khu vực")]
        public string KhuVuc { get; set; }

        [RegularExpression(@"[A-Za-z0-9]*$", ErrorMessage = "Tài khoản chứa kí tự đặc biệt")]
        [MaxLength(30, ErrorMessage = "Vượt quá số kí tự 30")]
        public string MaNVTrienKhai { get; set; }

        public string SdtSale { get; set; }

        [MaxLength(70, ErrorMessage = "Vượt quá số kí tự 70")]
        public string SaleNote { get; set; }

        public string PhiDichVu  { get; set; }

        public int TrangThai { get; set; }
       
    }
}