namespace Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        InStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        ZIP = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        ZIP = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoiceEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Article_Id = c.Int(),
                        Invoice_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .ForeignKey("dbo.Invoices", t => t.Invoice_Id)
                .Index(t => t.Article_Id)
                .Index(t => t.Invoice_Id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Tax = c.Double(nullable: false),
                        Other = c.Double(nullable: false),
                        Total = c.Double(nullable: false),
                        Status = c.Int(nullable: false),
                        BillCustomer_Id = c.Int(),
                        ShipCustomer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.BillCustomer_Id)
                .ForeignKey("dbo.Customers", t => t.ShipCustomer_Id)
                .Index(t => t.BillCustomer_Id)
                .Index(t => t.ShipCustomer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "ShipCustomer_Id", "dbo.Customers");
            DropForeignKey("dbo.InvoiceEntries", "Invoice_Id", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "BillCustomer_Id", "dbo.Customers");
            DropForeignKey("dbo.InvoiceEntries", "Article_Id", "dbo.Articles");
            DropIndex("dbo.Invoices", new[] { "ShipCustomer_Id" });
            DropIndex("dbo.Invoices", new[] { "BillCustomer_Id" });
            DropIndex("dbo.InvoiceEntries", new[] { "Invoice_Id" });
            DropIndex("dbo.InvoiceEntries", new[] { "Article_Id" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceEntries");
            DropTable("dbo.Customers");
            DropTable("dbo.Companies");
            DropTable("dbo.Articles");
        }
    }
}
