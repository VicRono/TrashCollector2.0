namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerAcctUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerAccounts", "AspUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerAccounts", "AspUserId");
        }
    }
}
