namespace PhotographerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShareAlbum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Albums", "OwnerId", "dbo.Photographers");
            DropIndex("dbo.Albums", new[] { "OwnerId" });
            CreateTable(
                "dbo.PhotographerAlbums",
                c => new
                    {
                        Photographer_Id = c.Int(nullable: false),
                        Album_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Photographer_Id, t.Album_Id })
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_Id, cascadeDelete: true)
                .Index(t => t.Photographer_Id)
                .Index(t => t.Album_Id);
            
            DropColumn("dbo.Albums", "OwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Albums", "OwnerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PhotographerAlbums", "Album_Id", "dbo.Albums");
            DropForeignKey("dbo.PhotographerAlbums", "Photographer_Id", "dbo.Photographers");
            DropIndex("dbo.PhotographerAlbums", new[] { "Album_Id" });
            DropIndex("dbo.PhotographerAlbums", new[] { "Photographer_Id" });
            DropTable("dbo.PhotographerAlbums");
            CreateIndex("dbo.Albums", "OwnerId");
            AddForeignKey("dbo.Albums", "OwnerId", "dbo.Photographers", "Id", cascadeDelete: true);
        }
    }
}
