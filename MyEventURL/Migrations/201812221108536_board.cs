namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class board : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boards", "Events", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boards", "Events");
        }
    }
}
