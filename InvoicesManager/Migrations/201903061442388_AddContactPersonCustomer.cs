namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddContactPersonCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ContactPerson", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ContactPerson");
        }
    }
}
