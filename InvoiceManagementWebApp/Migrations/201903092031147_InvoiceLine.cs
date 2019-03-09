namespace InvoiceManagementWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceLine : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InvoiceLines", "Quantity", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceLines", "NetAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceLines", "VatPrc", c => c.Int());
            AlterColumn("dbo.InvoiceLines", "GrossAmount", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceLines", "LineAmount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InvoiceLines", "LineAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceLines", "GrossAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceLines", "VatPrc", c => c.Int(nullable: false));
            AlterColumn("dbo.InvoiceLines", "NetAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.InvoiceLines", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
