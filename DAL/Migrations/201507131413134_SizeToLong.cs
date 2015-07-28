namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SizeToLong : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Files", "size", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Files", "size", c => c.Int(nullable: false));
        }
    }
}
