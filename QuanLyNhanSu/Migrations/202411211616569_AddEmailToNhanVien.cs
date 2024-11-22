namespace QuanLyNhanSu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailToNhanVien : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NhanViens", "Email", c => c.String(nullable: false ));
        }

        public override void Down()
        {
            DropColumn("dbo.NhanViens", "Email");
        }
    }
}
