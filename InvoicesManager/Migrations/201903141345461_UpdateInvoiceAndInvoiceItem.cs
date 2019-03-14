namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvoiceAndInvoiceItem : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM InvoiceItems");
            AddColumn("dbo.InvoiceItems", "VATRate", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "InvoiceNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.InvoiceItems", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.InvoiceItems", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Invoices", "CurrentMonthNumber");
            DropColumn("dbo.Invoices", "TotalAmount");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "TotalAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Invoices", "CurrentMonthNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.InvoiceItems", "Description", c => c.String());
            AlterColumn("dbo.InvoiceItems", "Type", c => c.String());
            DropColumn("dbo.Invoices", "InvoiceNumber");
            DropColumn("dbo.InvoiceItems", "VATRate");
        }
    }
}
