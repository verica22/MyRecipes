using ItLabs.MyRecipes.Core.DependencyInjection;
using System.Reflection;
using System.Web.Http;

namespace ItLabs.MyRecipes.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.EnableCors();

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           

            config.DependencyResolver = IoCConfig.RegisterWebApiDependencies(Assembly.GetExecutingAssembly());
        }
    }
}
