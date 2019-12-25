namespace RSSBackgroundWorkerBusiness.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_RSS_URL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Channel", "RSS_URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Channel", "RSS_URL");
        }
    }
}
