namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvoice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoiceItems", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceItems", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceItems", "VATRate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InvoiceItems", "VATRate", c => c.Double(nullable: false));
            AlterColumn("dbo.InvoiceItems", "Quantity", c => c.Double(nullable: false));
            AlterColumn("dbo.InvoiceItems", "UnitPrice", c => c.Double(nullable: false));
        }
    }
}
