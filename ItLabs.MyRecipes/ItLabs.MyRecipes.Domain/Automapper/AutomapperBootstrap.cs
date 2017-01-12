using AutoMapper;

namespace ItLabs.MyRecipes.Core.Automapper
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
