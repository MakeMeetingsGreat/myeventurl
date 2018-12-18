namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
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
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Timezone = c.String(),
                        Title = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Organizer = c.String(),
                        Email = c.String(nullable: false),
                        Reminder = c.Boolean(),
                        Format = c.String(),
                        sway = c.String(),
                        NoReply = c.Boolean(),
                        Forms = c.String(),
                        Created = c.DateTime(),
                        Style = c.String(),
                        Private = c.Boolean(),
                        Icon = c.Boolean(),
                        Views = c.Int(),
                        Engaged = c.Int(),
                    })
                .PrimaryKey(t => t.EventId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
            DropTable("dbo.Boards");
        }
    }
}
