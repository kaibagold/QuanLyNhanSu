namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThongBao : DbMigration
    {
        public override void Up()
        {
            //Tạo bảng ThongBaos
            CreateTable(
                "dbo.ThongBaos",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    LoaiThongBao = c.String(nullable: false, maxLength: 30, unicode: false),
                    MaPhieu = c.Int(),
                    TieuDe = c.String(),
                    MaNVGuiTB = c.String(nullable: false, maxLength: 30, unicode: false),
                    ThoiGianGuiTB = c.DateTime(nullable: false),
                    MaNVNhanTB = c.String(maxLength: 30, unicode: false),
                    ThoiGianDuyetTB = c.DateTime(),
                    TrangThai = c.Int(nullable: false)
                })
                .PrimaryKey(t => new { t.Id });
            AddForeignKey("dbo.ThongBaos", "MaNVGuiTB", "dbo.NhanViens", "MaNhanVien", cascadeDelete: false);
            AddForeignKey("dbo.ThongBaos", "MaNVNhanTB", "dbo.NhanViens", "MaNhanVien", cascadeDelete: false);

            CreateIndex("dbo.ThongBaos", "MaNVGuiTB");
            CreateIndex("dbo.ThongBaos", "MaNVNhanTB");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ThongBaos", "MaNVGuiTB", "dbo.NhanViens");
            DropForeignKey("dbo.ThongBaos", "MaNVNhanTB", "dbo.NhanViens");
        }
    }
}
