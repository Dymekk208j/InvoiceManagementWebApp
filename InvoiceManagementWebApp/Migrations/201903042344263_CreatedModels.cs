namespace InvoiceManagementWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                        Nip = c.String(),
                        Regon = c.String(),
                        City = c.String(),
                        PostCode = c.String(),
                        PhoneNumber = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.InvoiceLines",
                c => new
                    {
                        InvoiceLineId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VatPrc = c.Int(nullable: false),
                        GrossAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LineAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Invoice_InvoiceId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceLineId)
                .ForeignKey("dbo.Invoices", t => t.Invoice_InvoiceId)
                .Index(t => t.Invoice_InvoiceId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(),
                        CurrencyCode = c.String(),
                        PostingDate = c.DateTime(nullable: false),
                        DocumentDate = c.DateTime(nullable: false),
                        PaymentDue = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        Customer_CompanyId = c.Int(),
                        Vendor_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Companies", t => t.Customer_CompanyId)
                .ForeignKey("dbo.Companies", t => t.Vendor_CompanyId)
                .Index(t => t.Customer_CompanyId)
                .Index(t => t.Vendor_CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceLines", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Vendor_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "Customer_CompanyId", "dbo.Companies");
            DropIndex("dbo.Invoices", new[] { "Vendor_CompanyId" });
            DropIndex("dbo.Invoices", new[] { "Customer_CompanyId" });
            DropIndex("dbo.InvoiceLines", new[] { "Invoice_InvoiceId" });
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceLines");
            DropTable("dbo.Companies");
        }
    }
}
