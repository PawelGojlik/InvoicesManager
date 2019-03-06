namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NIPpropertyAsString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "NIP", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "NIP", c => c.Int(nullable: false));
        }
    }
}
