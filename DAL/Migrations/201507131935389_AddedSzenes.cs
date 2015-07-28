namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSzenes : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Files");
            CreateTable(
                "dbo.Szenes",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Description = c.String(),
                        Actress = c.Int(nullable: false),
                        Series = c.Int(nullable: false),
                        Region = c.Int(nullable: false),
                        Kategorie = c.Int(nullable: false),
                        Quality = c.Int(nullable: false),
                        Remark = c.String(),
                        FileNameOnly = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Files", "FileID", c => c.Guid(nullable: false));
            AddColumn("dbo.Files", "SzenesID", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Files", "FileID");
            CreateIndex("dbo.Files", "SzenesID");
            AddForeignKey("dbo.Files", "SzenesID", "dbo.Szenes", "ID", cascadeDelete: true);
            DropColumn("dbo.Files", "ID");
            DropColumn("dbo.Files", "Description");
            DropColumn("dbo.Files", "Kategorie");
            DropColumn("dbo.Files", "Quality");
            DropColumn("dbo.Files", "Remark");
            DropColumn("dbo.Files", "FileNameOnly");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Files", "FileNameOnly", c => c.String());
            AddColumn("dbo.Files", "Remark", c => c.String());
            AddColumn("dbo.Files", "Quality", c => c.Int(nullable: false));
            AddColumn("dbo.Files", "Kategorie", c => c.Int(nullable: false));
            AddColumn("dbo.Files", "Description", c => c.String());
            AddColumn("dbo.Files", "ID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Files", "SzenesID", "dbo.Szenes");
            DropIndex("dbo.Files", new[] { "SzenesID" });
            DropPrimaryKey("dbo.Files");
            DropColumn("dbo.Files", "SzenesID");
            DropColumn("dbo.Files", "FileID");
            DropTable("dbo.Szenes");
            AddPrimaryKey("dbo.Files", "ID");
        }
    }
}
