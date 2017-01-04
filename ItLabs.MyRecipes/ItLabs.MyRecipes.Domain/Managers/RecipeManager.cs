using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;
using AutoMapper;
using System;
using System.Linq;
using ItLabs.MyRecipes.Data;

namespace ItLabs.MyRecipes.Domain.Managers
{
    public class RecipeManager : IRecipeManager
    {
        public IRecipeRepository _recipeRepository { get; set; }

        public RecipeManager(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            var dbRecipes = _recipeRepository.GetRecipes();
            var recipes = Mapper.Map<IEnumerable<Recipe>>(dbRecipes);
            return recipes;
        }

        public void Save(Recipe recipe)
        {
            recipe.Id = 113;
            var existingRecipe = _recipeRepository.GetRecipes().SingleOrDefault(x => x.Id == recipe.Id);
            var newRecipe = (dynamic)null;
            if (existingRecipe == null)
            {
               newRecipe = new Data.Recipe { Name = recipe.Name, Description = recipe.Description, Done = recipe.Done, Favorites = recipe.Favorites };
                //add ingredients
                foreach (var i in recipe.RecipeIngredients.ToList())
                {
                    var existingIngredient = _recipeRepository.GetIngredients().SingleOrDefault(x => x.Name.ToLower() == i.IngredientName.ToLower());
                    //if ingredient exist
                    if (existingIngredient != null)
                    {
                        newRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Recipe = newRecipe, Ingredient = existingIngredient, Quantity = i.Quantity });
                    }
                    //if ingredient doesnt exist
                    else
                    {
                        var newIngredient = new Data.Ingredient() { Name = i.IngredientName, Measurement = i.IngredientMeasurement };
                        newRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Recipe = newRecipe, Ingredient = newIngredient, Quantity = i.Quantity });

                    }
                }
            }
            else
            {
                existingRecipe.Name = recipe.Name;existingRecipe.Description = recipe.Description; existingRecipe.Done = recipe.Done; existingRecipe.Favorites = recipe.Favorites;
                //add ingredients
                foreach (var i in recipe.RecipeIngredients.ToList())
                {
                    var existingIngredient = _recipeRepository.GetIngredients().SingleOrDefault(x => x.Name.ToLower() == i.IngredientName.ToLower());
                    //if ingredient exist
                    if (existingIngredient != null)
                    {
                        existingRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Ingredient = existingIngredient, Quantity = i.Quantity });
                    }
                    //if ingredient doesnt exist
                    else
                    {
                        var newIngredient = new Data.Ingredient() { Name = i.IngredientName, Measurement = i.IngredientMeasurement };
                        existingRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Ingredient = newIngredient, Quantity = i.Quantity });
                    }
                }
            }
            var dbRecipe = Mapper.Map<Data.Recipe>(existingRecipe);
            _recipeRepository.Save(existingRecipe);

        }

        public void Remove(int Id)
        {
            _recipeRepository.Remove(Id);
        }
        public void Edit(Recipe recipe)
        {
            var dbRecipe = Mapper.Map<Data.Recipe>(recipe);
            _recipeRepository.Edit(dbRecipe);
        }
        public Recipe FindById(int Id)
        {
            var result = _recipeRepository.FindById(Id);
            return Mapper.Map<Recipe>(result);
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            var dbIngredients = _recipeRepository.GetIngredients();
            var ingredient = Mapper.Map<IEnumerable<Ingredient>>(dbIngredients);
            return ingredient;
        }
        public IEnumerable<Recipe> SearchRecipes(string name, bool isDone, bool isFavourite)
        {
            var searchRecipe = _recipeRepository.SearchRecipes(name, isDone, isFavourite);
            var recipe = Mapper.Map<IEnumerable<Recipe>>(searchRecipe);
            return recipe;
        }

    }
}
