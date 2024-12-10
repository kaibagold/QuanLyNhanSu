namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VatTuCaNhans : DbMigration
    {
        public override void Up()
        {
            //Tạo bảng VatTuCaNhans
            CreateTable(
                "dbo.VatTuCaNhans",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MaNhanVien = c.String(nullable: false, maxLength: 30, unicode: false),
                    MaVatTu = c.String(nullable: false, maxLength: 128),
                    SoLuong = c.Int(nullable: false),
                    TinhTrang = c.Int(nullable: false)
                })
                .PrimaryKey(t => new { t.Id ,t.MaNhanVien});
            AddForeignKey("dbo.VatTuCaNhans", "MaNhanVien", "dbo.NhanViens", "MaNhanVien", cascadeDelete: false);
            AddForeignKey("dbo.VatTuCaNhans", "MaVatTu", "dbo.VatTus", "MaVatTu", cascadeDelete: false);

            CreateIndex("dbo.VatTuCaNhans", "MaNhanVien");
            CreateIndex("dbo.VatTuCaNhans", "MaVatTu");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VatTuCaNhans", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.VatTuCaNhans", "MaVatTu", "dbo.VatTus");
            DropIndex("dbo.VatTuCaNhans", new[] { "MaNhanVien" });
            DropIndex("dbo.VatTuCaNhans", new[] { "MaVatTu" });
            DropTable("dbo.VatTuCaNhans");
        }
    }
}
