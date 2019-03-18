namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvoice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Invoices", "TotalGross");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "TotalGross", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
