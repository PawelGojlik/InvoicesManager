namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceIssueDateNonNullable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.Invoices SET IssueDate='01-01-2001 00:00:00'");
            AlterColumn("dbo.Invoices", "IssueDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "IssueDate", c => c.DateTime());
        }
    }
}
