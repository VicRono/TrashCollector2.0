namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database_changed : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CollectorAccounts");
            CreateTable(
                "dbo.AccountBalances",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CollectorId = c.Int(nullable: false),
                        TotalBalance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.CollectorAccounts", t => t.CollectorId, cascadeDelete: true)
                .ForeignKey("dbo.CustomerAccounts", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CollectorId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        CustomerAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerAccounts", t => t.CustomerAccountId, cascadeDelete: true)
                .Index(t => t.CustomerAccountId);
            
            CreateTable(
                "dbo.PickupDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickUpDay = c.String(),
                        SuspendedStartDay = c.String(),
                        SuspendedEndDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CollectorAccounts", "CollectorId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CollectorAccounts", "CollectorName", c => c.String());
            AddColumn("dbo.CollectorAccounts", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerAccounts", "PickupDayId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CollectorAccounts", "CollectorId");
            CreateIndex("dbo.CollectorAccounts", "AddressId");
            CreateIndex("dbo.CustomerAccounts", "PickupDayId");
            AddForeignKey("dbo.CustomerAccounts", "PickupDayId", "dbo.PickupDays", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CollectorAccounts", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            DropColumn("dbo.CollectorAccounts", "EmployeeId");
            DropColumn("dbo.CollectorAccounts", "EmployeeName");
            DropColumn("dbo.CollectorAccounts", "ZipCode");
            DropColumn("dbo.CollectorAccounts", "ApplicationUserId");
            DropColumn("dbo.CustomerAccounts", "CustomerAddress");
            DropColumn("dbo.CustomerAccounts", "City");
            DropColumn("dbo.CustomerAccounts", "State");
            DropColumn("dbo.CustomerAccounts", "ZipCode");
            DropColumn("dbo.CustomerAccounts", "Day");
            DropColumn("dbo.CustomerAccounts", "OneTimePickup");
            DropColumn("dbo.CustomerAccounts", "StartDay");
            DropColumn("dbo.CustomerAccounts", "EndDay");
            DropColumn("dbo.CustomerAccounts", "ExtraPickUpDay");
            DropTable("dbo.TotalBalances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TotalBalances",
                c => new
                    {
                        accountId = c.Int(nullable: false, identity: true),
                        customerId = c.Int(nullable: false),
                        collectorId = c.Int(nullable: false),
                        totalBalance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.accountId);
            
            AddColumn("dbo.CustomerAccounts", "ExtraPickUpDay", c => c.Int());
            AddColumn("dbo.CustomerAccounts", "EndDay", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerAccounts", "StartDay", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerAccounts", "OneTimePickup", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerAccounts", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerAccounts", "ZipCode", c => c.String());
            AddColumn("dbo.CustomerAccounts", "State", c => c.String());
            AddColumn("dbo.CustomerAccounts", "City", c => c.String());
            AddColumn("dbo.CustomerAccounts", "CustomerAddress", c => c.String());
            AddColumn("dbo.CollectorAccounts", "ApplicationUserId", c => c.String());
            AddColumn("dbo.CollectorAccounts", "ZipCode", c => c.String());
            AddColumn("dbo.CollectorAccounts", "EmployeeName", c => c.String());
            AddColumn("dbo.CollectorAccounts", "EmployeeId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.AccountBalances", "CustomerId", "dbo.CustomerAccounts");
            DropForeignKey("dbo.AccountBalances", "CollectorId", "dbo.CollectorAccounts");
            DropForeignKey("dbo.CollectorAccounts", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "CustomerAccountId", "dbo.CustomerAccounts");
            DropForeignKey("dbo.CustomerAccounts", "PickupDayId", "dbo.PickupDays");
            DropIndex("dbo.CustomerAccounts", new[] { "PickupDayId" });
            DropIndex("dbo.Addresses", new[] { "CustomerAccountId" });
            DropIndex("dbo.CollectorAccounts", new[] { "AddressId" });
            DropIndex("dbo.AccountBalances", new[] { "CollectorId" });
            DropIndex("dbo.AccountBalances", new[] { "CustomerId" });
            DropPrimaryKey("dbo.CollectorAccounts");
            DropColumn("dbo.CustomerAccounts", "PickupDayId");
            DropColumn("dbo.CollectorAccounts", "AddressId");
            DropColumn("dbo.CollectorAccounts", "CollectorName");
            DropColumn("dbo.CollectorAccounts", "CollectorId");
            DropTable("dbo.PickupDays");
            DropTable("dbo.Addresses");
            DropTable("dbo.AccountBalances");
            AddPrimaryKey("dbo.CollectorAccounts", "EmployeeId");
        }
    }
}
