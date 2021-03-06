namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvoiceModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "TotalGross", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "TotalGross");
        }
    }
}
