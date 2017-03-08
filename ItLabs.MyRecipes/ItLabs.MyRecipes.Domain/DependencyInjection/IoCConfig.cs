using Autofac;
using ItLabs.MyRecipes.Data.Repository;
using ItLabs.MyRecipes.Core.Managers;
using System.Reflection;
using Autofac.Integration.WebApi;

namespace ItLabs.MyRecipes.Core.DependencyInjection
{
    public class IoCConfig
    {
        public static AutofacWebApiDependencyResolver RegisterWebApiDependencies(Assembly assembly)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(assembly);

            RegisterManagersAndRepositories(builder);

            var container = builder.Build();
            return new AutofacWebApiDependencyResolver(container);
        }

        public static void RegisterManagersAndRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<RecipeManager>().As<IRecipeManager>();

            //register repositories
            builder.RegisterType<RecipeRepository>().As<IRecipeRepository>();
            builder.RegisterType<IngredientRepository>().As<IIngredientRepository>();
        }
    }
}
