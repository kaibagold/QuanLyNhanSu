namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVatTusAndPhieuNhapsAndChiTietPhieuNhaps : DbMigration
    {
        public override void Up()
        {
            // Tạo bảng VatTus
            CreateTable(
                "dbo.VatTus",
                c => new
                {
                    MaVatTu = c.String(nullable: false, maxLength: 128),
                    TenVatTu = c.String(nullable: false),
                    SdtKhachHang = c.String(nullable: false),
                    DonViTinh = c.String(nullable: false),
                    SoLuong = c.Int(nullable: false),
                    TrangThai = c.Int(nullable: false)
                })
                .PrimaryKey(t => new { t.MaVatTu });

            // Tạo bảng PhieuNhaps
            CreateTable(
                "dbo.PhieuNhaps",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MaNVLenPhieu = c.String(nullable: false, maxLength: 30, unicode: false),
                    ThoiGianTaoPhieu = c.DateTime(nullable: false),
                    MaNVDuyetPhieu = c.String(maxLength: 30, unicode: false),
                    ThoiGianDuyetPhieu = c.DateTime(),
                    GhiChu = c.String(),
                    TrangThai = c.Int(nullable: false)
                })
                .PrimaryKey(t => new { t.Id });
            AddForeignKey("dbo.PhieuNhaps", "MaNVLenPhieu", "dbo.NhanViens", "MaNhanVien", cascadeDelete: false);
            AddForeignKey("dbo.PhieuNhaps", "MaNVDuyetPhieu", "dbo.NhanViens", "MaNhanVien", cascadeDelete: false);

            CreateIndex("dbo.PhieuNhaps", "MaNVLenPhieu");
            CreateIndex("dbo.PhieuNhaps", "MaNVDuyetPhieu");

            // Tạo bảng ChiTietPhieuNhaps
            CreateTable(
                "dbo.ChiTietPhieuNhaps",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MaPhieu = c.Int(nullable: false),
                    MaVatTu = c.String(nullable: false, maxLength: 128),
                    SoLuong = c.Int(nullable: false)
                })
                .PrimaryKey(t => new { t.Id, t.MaPhieu });
            AddForeignKey("dbo.ChiTietPhieuNhaps", "MaPhieu", "dbo.PhieuNhaps", "Id", cascadeDelete: false);
            AddForeignKey("dbo.ChiTietPhieuNhaps", "MaVatTu", "dbo.VatTus", "MaVatTu", cascadeDelete: false);

            CreateIndex("dbo.ChiTietPhieuNhaps", "MaPhieu");
            CreateIndex("dbo.ChiTietPhieuNhaps", "MaVatTu");

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuNhaps", "MaNVDuyetPhieu", "dbo.NhanViens");
            DropForeignKey("dbo.PhieuNhaps", "MaNVLenPhieu", "dbo.NhanViens");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "MaPhieu", "dbo.PhieuNhaps");
            DropForeignKey("dbo.ChiTietPhieuNhaps", "MaVatTu", "dbo.VatTus");
            DropIndex("dbo.PhieuNhaps", new[] { "MaNVDuyetPhieu" });
            DropIndex("dbo.PhieuNhaps", new[] { "MaNVLenPhieu" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "MaPhieu" });
            DropIndex("dbo.ChiTietPhieuNhaps", new[] { "MaVatTu" });
            DropTable("dbo.VatTus");
            DropTable("dbo.PhieuNhaps");
            DropTable("dbo.ChiTietPhieuNhaps");
        }
    }
}
