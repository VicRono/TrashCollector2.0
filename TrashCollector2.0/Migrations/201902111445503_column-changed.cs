namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnchanged : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AccountBalances", name: "CustomerName", newName: "CustomerId");
            RenameIndex(table: "dbo.AccountBalances", name: "IX_CustomerName", newName: "IX_CustomerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AccountBalances", name: "IX_CustomerId", newName: "IX_CustomerName");
            RenameColumn(table: "dbo.AccountBalances", name: "CustomerId", newName: "CustomerName");
        }
    }
}
