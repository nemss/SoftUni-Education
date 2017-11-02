namespace _1.CodeFirstStudentSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTimeChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
