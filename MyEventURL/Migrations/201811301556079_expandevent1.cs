namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expandevent1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "NoReply", c => c.Boolean());
            AlterColumn("dbo.Events", "Created", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Created", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Events", "NoReply", c => c.Boolean(nullable: false));
        }
    }
}
