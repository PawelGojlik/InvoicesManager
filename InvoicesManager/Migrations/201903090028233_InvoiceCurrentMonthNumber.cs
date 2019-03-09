namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceCurrentMonthNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "CurrentMonthNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "CurrentMonthNumber", c => c.String(maxLength: 20));
        }
    }
}
