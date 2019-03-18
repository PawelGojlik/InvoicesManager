namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateInvoiceDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "PhoneNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Companies", "ContactPerson", c => c.String(maxLength: 100));
            AddColumn("dbo.Companies", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Customers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        ZipCode = c.String(nullable: false, maxLength: 6),
                        City = c.String(nullable: false, maxLength: 30),
                        NIP = c.String(nullable: false, maxLength: 10),
                        PhoneNumber = c.String(maxLength: 20),
                        ContactPerson = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Companies", "Discriminator");
            DropColumn("dbo.Companies", "ContactPerson");
            DropColumn("dbo.Companies", "PhoneNumber");
        }
    }
}
