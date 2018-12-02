namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _private : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Private", c => c.Boolean());
            AlterColumn("dbo.Events", "Views", c => c.Int());
            AlterColumn("dbo.Events", "Engaged", c => c.Int());
            AlterColumn("dbo.Events", "search", c => c.Boolean());
            AlterColumn("dbo.Events", "Facebook", c => c.Int());
            AlterColumn("dbo.Events", "AllDay", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "AllDay", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Events", "Facebook", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "search", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Events", "Engaged", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "Views", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "Private");
        }
    }
}
