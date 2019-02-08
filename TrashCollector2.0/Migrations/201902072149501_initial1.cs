namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PickupDays", "PickUpDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PickupDays", "SuspendedStartDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PickupDays", "SuspendedEndDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PickupDays", "SuspendedEndDate", c => c.String());
            AlterColumn("dbo.PickupDays", "SuspendedStartDay", c => c.String());
            AlterColumn("dbo.PickupDays", "PickUpDay", c => c.String());
        }
    }
}
