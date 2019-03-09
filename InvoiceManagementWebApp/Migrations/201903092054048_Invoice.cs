namespace InvoiceManagementWebApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Invoice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "InvoiceNo", c => c.String(nullable: false));
            AlterColumn("dbo.Invoices", "CurrencyCode", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "CurrencyCode", c => c.String());
            AlterColumn("dbo.Invoices", "InvoiceNo", c => c.String());
        }
    }
}
