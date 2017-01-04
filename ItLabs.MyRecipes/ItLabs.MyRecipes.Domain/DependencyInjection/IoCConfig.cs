using Autofac;
using Autofac.Integration.Mvc;
using ItLabs.MyRecipes.Data.Repository;
using ItLabs.MyRecipes.Domain.Managers;
using System.Reflection;
using System.Web.Mvc;

namespace ItLabs.MyRecipes.Domain.DependencyInjection
{
    public class IoCConfig
    {
        public static void RegisterDependencies(Assembly mvcAssembly)
        {
            var builder = new ContainerBuilder();

            //register controllers
            builder.RegisterControllers(mvcAssembly).InstancePerRequest();
            builder.RegisterAssemblyModules(mvcAssembly);

            //register managers
            builder.RegisterType<RecipeManager>().As<IRecipeManager>();

            //register repositories
            builder.RegisterType<RecipeRepository>().As<IRecipeRepository>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}
