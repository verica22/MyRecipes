using AutoMapper;

namespace ItLabs.MyRecipes.Domain.Automapper
{
    public class AutomapperBootstrap
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MyRecipesProfile>();

            });
        }
    }
}
