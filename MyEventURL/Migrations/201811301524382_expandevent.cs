namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expandevent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "NoReply", c => c.Boolean(nullable: true));
            AddColumn("dbo.Events", "Forms", c => c.String());
            AddColumn("dbo.Events", "Created", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Created");
            DropColumn("dbo.Events", "Forms");
            DropColumn("dbo.Events", "NoReply");
        }
    }
}
