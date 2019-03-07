namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AbstractCustomerCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(maxLength: 20),
                        ContactPerson = c.String(maxLength: 100),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        ZipCode = c.String(nullable: false, maxLength: 6),
                        City = c.String(nullable: false, maxLength: 30),
                        NIP = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Companies", "PhoneNumber");
            DropColumn("dbo.Companies", "ContactPerson");
            DropColumn("dbo.Companies", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Companies", "ContactPerson", c => c.String(maxLength: 100));
            AddColumn("dbo.Companies", "PhoneNumber", c => c.String(maxLength: 20));
            DropTable("dbo.Customers");
        }
    }
}
