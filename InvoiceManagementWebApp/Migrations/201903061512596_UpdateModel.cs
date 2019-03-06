namespace InvoiceManagementWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "Relation", c => c.Int(nullable: false));
            DropColumn("dbo.Companies", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Companies", "Relation");
        }
    }
}
