namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoardName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boards", "BoardName", c => c.String());
            AddColumn("dbo.Boards", "TeamCalendar", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boards", "TeamCalendar");
            DropColumn("dbo.Boards", "BoardName");
        }
    }
}
