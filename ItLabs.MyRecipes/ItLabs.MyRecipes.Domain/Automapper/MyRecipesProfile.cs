﻿using AutoMapper;

namespace ItLabs.MyRecipes.Domain.Automapper
{
    //todo
    //try using ReverseMap for Recipe and Ingredient for readability 

    public class MyRecipesProfile : Profile
    {
        public MyRecipesProfile()
        {
            CreateMap<Data.RecipeIngredients, RecipeIngredient>()
               .ForMember(d => d.RecipeName, o => o.MapFrom(x => x.Recipe.Name))
               .ForMember(d => d.IngredientName, o => o.MapFrom(x => x.Ingredient.Name))
               .ForMember(d => d.IngredientMeasurement, o => o.MapFrom(x => x.Ingredient.Measurement));

            CreateMap<Data.Recipe, Recipe>()
                  .ForMember(d => d.RecipeIngredients, o => o.MapFrom(x => x.RecipeIngredients));

            CreateMap<Data.Ingredient, Ingredient>()
                 .ForMember(d => d.RecipeIngredients, o => o.MapFrom(x => x.RecipeIngredients));

            CreateMap<Recipe, Data.Recipe>()
                  .ForMember(d => d.RecipeIngredients, o => o.MapFrom(x => x.RecipeIngredients));

            CreateMap<Ingredient, Data.Ingredient>()
                .ForMember(d => d.RecipeIngredients, o => o.MapFrom(x => x.RecipeIngredients));

            CreateMap<RecipeIngredient, Data.RecipeIngredients>()
                .ForMember(d => d.Recipe, o => o.Ignore())
                .ForMember(d => d.Ingredient, o => o.Ignore());
        }
    }
}
