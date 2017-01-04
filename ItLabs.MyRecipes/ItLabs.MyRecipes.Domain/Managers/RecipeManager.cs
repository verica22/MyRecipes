using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;
using AutoMapper;
using System.Linq;
using ItLabs.MyRecipes.Domain.Validations;
using ItLabs.MyRecipes.Domain.Responses;
using System;

namespace ItLabs.MyRecipes.Domain.Managers
{
    //todo
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

        public Recipe Get(int Id)
        {
            var dbRecipe = _recipeRepository.GetRecipe(Id);
            var recipe = Mapper.Map<Recipe>(dbRecipe);
            return recipe;
        }

        //see repository comments
        public IEnumerable<Recipe> Search(string name, bool isDone, bool isFavourite)
        {
            var dbRecipes = _recipeRepository.Search(name, isDone, isFavourite);
            var recipes = Mapper.Map<IEnumerable<Recipe>>(dbRecipes);
            return recipes;
        }

        public ResponseBase SaveRecipe(Recipe recipe)
        {
          //recipe.Id = 113;

            var response = new ResponseBase();

            var validator = new RecipeValidator();
            var validationResult = validator.Validate(recipe);

            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            Data.Recipe dataRecipe;
           
            if (recipe.Id == 0)
            {
                dataRecipe = new Data.Recipe
                {
                    Name = recipe.Name,
                    Description = recipe.Description,
                    IsDone = recipe.IsDone,
                    IsFavorite = recipe.IsFavorite
                };
            }
            else
            {
                dataRecipe = _recipeRepository.GetRecipe(recipe.Id);
               // dataRecipe = Mapper.Map<Data.Recipe>(recipe);
                dataRecipe.Name = recipe.Name;
                dataRecipe.Description = recipe.Description;
                dataRecipe.IsDone = recipe.IsDone;
                dataRecipe.IsFavorite = recipe.IsFavorite;
                
            }

            foreach (var recipeIngredient in recipe.RecipeIngredients)
            {
                var dataIngredient = _recipeRepository.GetIngredient(recipeIngredient.IngredientName);
                if (dataIngredient == null)
                {
                    dataIngredient = new Data.Ingredient()
                    {
                        Name = recipeIngredient.IngredientName,
                        Measurement = recipeIngredient.Measurement
                    };
                }

                dataRecipe.RecipeIngredients.Add(new Data.RecipeIngredients
                {
                    Recipe = recipe.Id == 0 ? dataRecipe : null,
                    Ingredient = dataIngredient,
                    Quantity = recipeIngredient.Quantity
                });
            }

            //var existingRecipe = _recipeRepository.GetRecipes().SingleOrDefault(x => x.Id == recipe.Id);
            //var newRecipe = (dynamic)null;
            //if (existingRecipe == null)
            //{
            //    newRecipe = new Data.Recipe { Name = recipe.Name, Description = recipe.Description, IsDone = recipe.IsDone, IsFavorite = recipe.IsFavorite };
            //    //add ingredients
            //    foreach (var i in recipe.RecipeIngredients.ToList())
            //    {
            //        var existingIngredient = _recipeRepository.GetIngredients().SingleOrDefault(x => x.Name.ToLower() == i.IngredientName.ToLower());
            //        //if ingredient exist
            //        if (existingIngredient != null)
            //        {
            //            newRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Recipe = newRecipe, Ingredient = existingIngredient, Quantity = i.Quantity });
            //        }
            //        //if ingredient doesnt exist
            //        else
            //        {
            //            var newIngredient = new Data.Ingredient() { Name = i.IngredientName, Measurement = i.IngredientMeasurement };
            //            newRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Recipe = newRecipe, Ingredient = newIngredient, Quantity = i.Quantity });

            //        }
            //    }
            //}
            //else
            //{
            //    existingRecipe.Name = recipe.Name; existingRecipe.Description = recipe.Description; existingRecipe.IsDone = recipe.IsDone; existingRecipe.IsFavorite = recipe.IsFavorite;
            //    //add ingredients
            //    foreach (var i in recipe.RecipeIngredients.ToList())
            //    {
            //        var existingIngredient = _recipeRepository.GetIngredients().SingleOrDefault(x => x.Name.ToLower() == i.IngredientName.ToLower());
            //        //if ingredient exist
            //        if (existingIngredient != null)
            //        {
            //            existingRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Ingredient = existingIngredient, Quantity = i.Quantity });
            //        }
            //        //if ingredient doesnt exist
            //        else
            //        {
            //            var newIngredient = new Data.Ingredient() { Name = i.IngredientName, Measurement = i.IngredientMeasurement };
            //            existingRecipe.RecipeIngredients.Add(new Data.RecipeIngredients { Ingredient = newIngredient, Quantity = i.Quantity });
            //        }
            //    }
            //}

            _recipeRepository.Save(dataRecipe);
            return response;
        }


        public void Remove(int id)
        {
            if (id == 0)
                return;

            _recipeRepository.Remove(id);
        }


        public void Update(Recipe recipe)
        {
            var dbRecipe = Mapper.Map<Data.Recipe>(recipe);
            _recipeRepository.Update(dbRecipe);
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
           
            var dbIngredients = _recipeRepository.GetIngredients();
            var ingredients = Mapper.Map<IEnumerable<Ingredient>>(dbIngredients);
            return ingredients;
        }

        public Ingredient GetIngredient(string name)
        {
            var dbIngredients = _recipeRepository.GetIngredients();
            var ingredients = Mapper.Map<Ingredient>(dbIngredients);
            return ingredients;
        }
    }
}
