namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class icon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Icon", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Icon");
        }
    }
}
