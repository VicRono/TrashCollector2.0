namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnaddedcollector : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CollectorAccounts", "AspUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CollectorAccounts", "AspUserId");
        }
    }
}
