using InvoiceManagementWebApp.Models.DatabaseModels;

namespace InvoiceManagementWebApp.Migrations
{
    using System.Data.Entity.Migrations;
  
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
           
        }
    }
}
