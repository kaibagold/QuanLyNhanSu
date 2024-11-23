namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSwapsAndChiTietSwaps : DbMigration
    {
        public override void Up()
        {
            // Tạo bảng Swaps
            CreateTable(
                "dbo.Swaps",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MaHopDong = c.String(nullable: false, maxLength: 128),
                    TenKhachHang = c.String(nullable: false),
                    SdtKhachHang = c.String(nullable: false),
                    DiaChiKH = c.String(nullable: false),
                    KhuVuc = c.String(nullable: false),
                    // Sửa kiểu dữ liệu để khớp với varchar(30, unicode: false)
                    MaNVLenPhieu = c.String(nullable: false, maxLength: 30, unicode: false),
                    MaNVTrienKhai = c.String(maxLength: 30, unicode: false),
                    SdtSale = c.Int(nullable: false),
                    SaleNote = c.String(),
                    PhiDichVu = c.String(nullable: false),
                    TrangThai = c.Int(nullable: false)
                })
                .PrimaryKey(t => new { t.Id, t.MaHopDong });

            AddForeignKey("dbo.Swaps", "MaNVLenPhieu", "dbo.NhanViens", "MaNhanVien", cascadeDelete: false);
            AddForeignKey("dbo.Swaps", "MaNVTrienKhai", "dbo.NhanViens", "MaNhanVien", cascadeDelete: false);

            CreateIndex("dbo.Swaps", "MaNVLenPhieu");
            CreateIndex("dbo.Swaps", "MaNVTrienKhai");

            // Tạo bảng ChiTietSwaps
            CreateTable(
                "dbo.ChiTietSwaps",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MaHopDong = c.String(nullable: false, maxLength: 128),
                    TenKhachHang = c.String(nullable: false),
                    SdtKhachHang = c.String(nullable: false),
                    DiaChiKH = c.String(nullable: false),
                    KhuVuc = c.String(nullable: false),
                    // Sửa kiểu dữ liệu để khớp với varchar(30)
                    MaNVLenPhieu = c.String(nullable: false, maxLength: 30, unicode: false),
                    MaNVTrienKhai = c.String(nullable: false, maxLength: 30, unicode: false),
                    SdtSale = c.Int(nullable: false),
                    SaleNote = c.String(),
                    PhiDichVu = c.String(nullable: false),
                    ThoiGianNhanCa = c.DateTime(nullable: false),
                    ThoiGianHoanTat = c.DateTime(),
                    DanhGia = c.Int(),
                    TrangThai = c.Int(nullable: false)
                })
                .PrimaryKey(t => new { t.Id, t.MaHopDong });
        }

        public override void Down()
        {
            DropForeignKey("dbo.Swaps", "MaNVTrienKhai", "dbo.NhanViens");
            DropForeignKey("dbo.Swaps", "MaNVLenPhieu", "dbo.NhanViens");
            DropIndex("dbo.Swaps", new[] { "MaNVTrienKhai" });
            DropIndex("dbo.Swaps", new[] { "MaNVLenPhieu" });
            DropTable("dbo.ChiTietSwaps");
            DropTable("dbo.Swaps");
        }
    }
}
