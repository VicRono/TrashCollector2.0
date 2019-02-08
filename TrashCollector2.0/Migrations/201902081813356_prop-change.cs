namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PickupDays", "PickUpDay", c => c.DateTime());
            AlterColumn("dbo.PickupDays", "SuspendedStartDay", c => c.DateTime());
            AlterColumn("dbo.PickupDays", "SuspendedEndDate", c => c.DateTime());
            AlterColumn("dbo.PickupDays", "ExtraPickUp", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PickupDays", "ExtraPickUp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PickupDays", "SuspendedEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PickupDays", "SuspendedStartDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PickupDays", "PickUpDay", c => c.DateTime(nullable: false));
        }
    }
}
