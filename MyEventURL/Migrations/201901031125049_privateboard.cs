namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class privateboard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boards", "Private", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boards", "Private");
        }
    }
}
