namespace MyEventURL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingschema : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "search");
            DropColumn("dbo.Events", "Facebook");
            DropColumn("dbo.Events", "AllDay");
            DropColumn("dbo.Events", "Recurring");
            DropColumn("dbo.Events", "SocialCommentsEngine");
            DropColumn("dbo.Events", "TwitterDataWidget");
            DropColumn("dbo.Events", "YammerNetwork");
            DropColumn("dbo.Events", "SummaryEngine");
            DropColumn("dbo.Events", "youtube");
            DropColumn("dbo.Events", "storify");
            DropColumn("dbo.Events", "surveymonkey");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "surveymonkey", c => c.String());
            AddColumn("dbo.Events", "storify", c => c.String());
            AddColumn("dbo.Events", "youtube", c => c.String());
            AddColumn("dbo.Events", "SummaryEngine", c => c.String());
            AddColumn("dbo.Events", "YammerNetwork", c => c.String());
            AddColumn("dbo.Events", "TwitterDataWidget", c => c.String());
            AddColumn("dbo.Events", "SocialCommentsEngine", c => c.String());
            AddColumn("dbo.Events", "Recurring", c => c.String());
            AddColumn("dbo.Events", "AllDay", c => c.Boolean());
            AddColumn("dbo.Events", "Facebook", c => c.Int());
            AddColumn("dbo.Events", "search", c => c.Boolean());
        }
    }
}
