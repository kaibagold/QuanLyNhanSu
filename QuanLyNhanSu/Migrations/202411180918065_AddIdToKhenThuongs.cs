namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdToKhenThuongs : DbMigration
    {
        public override void Up()
        {
            // 1. Thêm cột Id (auto-increment)
            AddColumn("dbo.KhenThuongs", "Id", c => c.Int(nullable: false, identity: true));

            // 2. Xóa khóa chính cũ (sử dụng tên chính xác từ SQL Server)
            Sql("ALTER TABLE dbo.KhenThuongs DROP CONSTRAINT PK_KhenThuongs_1");

            // 3. Đặt Id làm khóa chính
            AddPrimaryKey("dbo.KhenThuongs", "Id");
        }
        
        public override void Down()
        {
            // 1. Xóa khóa chính mới
            DropPrimaryKey("dbo.KhenThuongs");

            // 2. Đặt lại MaNhanVien làm khóa chính
            AddPrimaryKey("dbo.KhenThuongs", "MaNhanVien");

            // 3. Xóa cột Id
            DropColumn("dbo.KhenThuongs", "Id");
        }
    }
}
