namespace InvoicesManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inheritance : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Companies", newName: "Contacts");
            AddColumn("dbo.Contacts", "PhoneNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Contacts", "ContactPerson", c => c.String(maxLength: 100));
            AddColumn("dbo.Contacts", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.Customers");
        }
        
        public override void Down()
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
            
            DropColumn("dbo.Contacts", "Discriminator");
            DropColumn("dbo.Contacts", "ContactPerson");
            DropColumn("dbo.Contacts", "PhoneNumber");
            RenameTable(name: "dbo.Contacts", newName: "Companies");
        }
    }
}
