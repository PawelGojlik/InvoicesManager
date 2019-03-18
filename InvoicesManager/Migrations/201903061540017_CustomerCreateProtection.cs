namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerCreateProtection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ZipCode", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Customers", "NIP", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "NIP", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "ZipCode", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
