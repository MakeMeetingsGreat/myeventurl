namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Title", c => c.String(nullable: true));
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: true));
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Location", c => c.String());
            AlterColumn("dbo.Events", "Description", c => c.String());
            AlterColumn("dbo.Events", "Title", c => c.String());
        }
    }
}
