namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Kategorie = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Description = c.String(),
                        Kategorie = c.Int(nullable: false),
                        Quality = c.Int(nullable: false),
                        Uri = c.String(),
                        Remark = c.String(),
                        size = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FileNameOnly = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Qualities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Qualities");
            DropTable("dbo.Files");
            DropTable("dbo.Favorites");
            DropTable("dbo.Categories");
        }
    }
}
