using FluentValidation.Mvc;
using ItLabs.MyRecipes.Domain.Automapper;
using ItLabs.MyRecipes.Domain.DependencyInjection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace ItLabs.MyRecipes.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IoCConfig.RegisterDependencies(typeof(MvcApplication).Assembly);
            AutomapperBootstrap.Initialize();

            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
