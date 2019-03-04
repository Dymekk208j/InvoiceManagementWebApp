namespace InvoiceManagementWebApp.Migrations
{
    using System.Data.Entity.Migrations;
  
    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
           
        }
    }
}
