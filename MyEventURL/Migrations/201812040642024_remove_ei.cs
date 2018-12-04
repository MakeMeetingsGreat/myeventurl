namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_ei : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EngagementInfoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EngagementInfoes",
                c => new
                    {
                        EngagementInfoID = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        ApplicationID = c.String(),
                        ItemID = c.String(),
                        UserID = c.String(),
                        ActionID = c.String(),
                    })
                .PrimaryKey(t => t.EngagementInfoID);
            
        }
    }
}
