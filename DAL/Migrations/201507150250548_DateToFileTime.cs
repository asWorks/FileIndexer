namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateToFileTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "FileTime", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "FileTime");
        }
    }
}
