using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InvoiceManagementWebApp.Models.DatabaseModels.DatabaseInitializer
{
    public class DbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            CreateUsers(context);
        }
        
        private void CreateUsers(ApplicationDbContext context)
        {
            UserManager<ApplicationUser> userManager =
                new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            ApplicationUser user = new ApplicationUser
            {
                UserName = "Dymek",
                Email = "Kontakt@damiandziura.pl",
                //ContactDetails = new Contact()
                //{
                //    DiscordId = "DiscordID",
                //    FacebookLink = "FacebookLink",
                //    PhoneNo = "123-123-123",
                //    SkypeId = "SkypeID"
                //},
                //Person = new Person()
                //{
                //    FirstName = "Damian"
                //}
            };
            
            userManager.Create(user, "Damian13!");

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            userManager.AddToRole(user.Id, "Admin");
        }

    }
}