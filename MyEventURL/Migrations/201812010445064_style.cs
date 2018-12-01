namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class style : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Style", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Style");
        }
    }
}
