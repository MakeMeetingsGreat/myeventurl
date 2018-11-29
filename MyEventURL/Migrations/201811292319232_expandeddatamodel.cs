namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expandeddatamodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        BoardID = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(nullable: false),
                        View = c.String(),
                    })
                .PrimaryKey(t => t.BoardID);
            
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
        
        public override void Down()
        {
            DropTable("dbo.EngagementInfoes");
            DropTable("dbo.Boards");
        }
    }
}
