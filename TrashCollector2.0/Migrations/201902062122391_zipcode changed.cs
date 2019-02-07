namespace TrashCollector2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class zipcodechanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "ZipCode", c => c.Int(nullable: false));
        }
    }
}
