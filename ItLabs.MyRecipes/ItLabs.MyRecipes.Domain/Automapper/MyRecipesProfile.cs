using AutoMapper;

namespace ItLabs.MyRecipes.Domain.Automapper
{
    public class MyRecipesProfile : Profile
    {
        public MyRecipesProfile()
        {
            CreateMap<Data.RecipeIngredients, RecipeIngredient>()
               .ForMember(d => d.RecipeName, o => o.MapFrom(x => x.Recipe.Name))
               .ForMember(d => d.IngredientName, o => o.MapFrom(x => x.Ingredient.Name))
               .ForMember(d => d.Measurement, o => o.MapFrom(x => x.Ingredient.Measurement));


            CreateMap<Data.Recipe, Recipe>()
                  .ForMember(d => d.RecipeIngredients, o => o.MapFrom(x => x.RecipeIngredients))
                  .ReverseMap();

            CreateMap<Data.Ingredient, Ingredient>()
                 .ForMember(d => d.RecipeIngredients, o => o.MapFrom(x => x.RecipeIngredients))
                 .ReverseMap();

            CreateMap<RecipeIngredient, Data.RecipeIngredients>()
                .ForMember(d => d.Recipe, o => o.Ignore())
                .ForMember(d => d.Ingredient, o => o.Ignore());
        }
    }
}
