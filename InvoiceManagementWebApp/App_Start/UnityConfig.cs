using InvoiceManagementWebApp.Repository;
using LeagueOfLegendsFindTeamApp.Controllers;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace InvoiceManagementWebApp
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            //  container.RegisterType<IRepository<GamerProfile, int>, GamerProfileRepository>();


            container.RegisterType<AccountController>(new InjectionConstructor(typeof(CompanyRepository)));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}