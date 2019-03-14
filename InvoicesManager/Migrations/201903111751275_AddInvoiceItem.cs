namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceItems", "InvoiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceItems", "InvoiceId");
            AddForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceItems", "InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceItems", new[] { "InvoiceId" });
            DropColumn("dbo.InvoiceItems", "InvoiceId");
        }
    }
}
