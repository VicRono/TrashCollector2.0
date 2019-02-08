namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedextrapickup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExtraPickUps", "CustomerId", "dbo.CustomerAccounts");
            DropIndex("dbo.ExtraPickUps", new[] { "CustomerId" });
            AddColumn("dbo.PickupDays", "ExtraPickUp", c => c.DateTime(nullable: false));
            DropTable("dbo.ExtraPickUps");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExtraPickUps",
                c => new
                    {
                        ExtraDay = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExtraDay);
            
            DropColumn("dbo.PickupDays", "ExtraPickUp");
            CreateIndex("dbo.ExtraPickUps", "CustomerId");
            AddForeignKey("dbo.ExtraPickUps", "CustomerId", "dbo.CustomerAccounts", "CustomerId", cascadeDelete: true);
        }
    }
}
