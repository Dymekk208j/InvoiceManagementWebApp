namespace InvoiceManagementWebApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InvoiceLine1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InvoiceLines", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceLines", new[] { "Invoice_InvoiceId" });
            AlterColumn("dbo.InvoiceLines", "Invoice_InvoiceId", c => c.Int());
            CreateIndex("dbo.InvoiceLines", "Invoice_InvoiceId");
            AddForeignKey("dbo.InvoiceLines", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceLines", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.InvoiceLines", new[] { "Invoice_InvoiceId" });
            AlterColumn("dbo.InvoiceLines", "Invoice_InvoiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.InvoiceLines", "Invoice_InvoiceId");
            AddForeignKey("dbo.InvoiceLines", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId", cascadeDelete: true);
        }
    }
}
