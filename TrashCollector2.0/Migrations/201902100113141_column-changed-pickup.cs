namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnchangedpickup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountBalances",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        CustomerName = c.Int(nullable: false),
                        AspUserId = c.String(),
                        TotalBalance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.CustomerAccounts", t => t.CustomerName, cascadeDelete: true)
                .Index(t => t.CustomerName);
            
            CreateTable(
                "dbo.CustomerAccounts",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerAddressId = c.Int(nullable: false),
                        AspUserId = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Addresses", t => t.CustomerAddressId, cascadeDelete: true)
                .Index(t => t.CustomerAddressId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CollectorAccounts",
                c => new
                    {
                        CollectorId = c.Int(nullable: false, identity: true),
                        CollectorName = c.String(),
                        CollectorAddressId = c.Int(nullable: false),
                        TotalPickups = c.Int(nullable: false),
                        MyPickups = c.Int(nullable: false),
                        Pickupcompleted = c.String(),
                        AspUserId = c.String(),
                    })
                .PrimaryKey(t => t.CollectorId)
                .ForeignKey("dbo.Addresses", t => t.CollectorAddressId, cascadeDelete: true)
                .Index(t => t.CollectorAddressId);
            
            CreateTable(
                "dbo.PickupDays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickUpDay = c.String(),
                        SuspendedStartDay = c.String(),
                        SuspendedEndDay = c.String(),
                        ExtraPickUp = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerAccounts", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserRole = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PickupDays", "CustomerID", "dbo.CustomerAccounts");
            DropForeignKey("dbo.CollectorAccounts", "CollectorAddressId", "dbo.Addresses");
            DropForeignKey("dbo.AccountBalances", "CustomerName", "dbo.CustomerAccounts");
            DropForeignKey("dbo.CustomerAccounts", "CustomerAddressId", "dbo.Addresses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PickupDays", new[] { "CustomerID" });
            DropIndex("dbo.CollectorAccounts", new[] { "CollectorAddressId" });
            DropIndex("dbo.CustomerAccounts", new[] { "CustomerAddressId" });
            DropIndex("dbo.AccountBalances", new[] { "CustomerName" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PickupDays");
            DropTable("dbo.CollectorAccounts");
            DropTable("dbo.Addresses");
            DropTable("dbo.CustomerAccounts");
            DropTable("dbo.AccountBalances");
        }
    }
}
