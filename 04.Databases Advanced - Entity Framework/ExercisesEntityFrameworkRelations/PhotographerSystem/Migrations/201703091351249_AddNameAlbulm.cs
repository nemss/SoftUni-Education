namespace PhotographerSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameAlbulm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Albums", "Name");
        }
    }
}
