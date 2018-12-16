namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailrequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Email", c => c.String());
        }
    }
}
