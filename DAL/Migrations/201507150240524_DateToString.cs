namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Files", "strDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Files", "strDate");
        }
    }
}
