namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class boardemail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Boards", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Boards", "Email");
        }
    }
}
