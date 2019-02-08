namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnaddedpickup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PickupDays", "ExtraDay", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PickupDays", "ExtraDay");
        }
    }
}
