namespace InvoiceManagementWebApp.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Invoice1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "InvoiceType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "InvoiceType");
        }
    }
}
