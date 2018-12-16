namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remindertobool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Reminder", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Reminder", c => c.Int(nullable: false));
        }
    }
}
