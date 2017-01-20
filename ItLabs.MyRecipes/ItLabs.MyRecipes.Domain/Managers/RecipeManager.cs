using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;
using AutoMapper;
using System.Linq;
using ItLabs.MyRecipes.Core.Validations;
using ItLabs.MyRecipes.Core.Responses;
using AutoMapper.QueryableExtensions;
using ItLabs.MyRecipes.Core.Requests;
using System;
using ItLabs.MyRecipes.Domain.Validations;

namespace ItLabs.MyRecipes.Core.Managers
{
    public class RecipeManager : IRecipeManager
    {
        public IRecipeRepository _recipeRepository { get; set; }
        public IIngredientRepository _ingredientRepository { get; set; }

        public RecipeManager(IRecipeRepository recipeRepository, IIngredientRepository ingredientRepository)
        {
            _recipeRepository = recipeRepository;
            _ingredientRepository = ingredientRepository;
        }

        public Recipe GetRecipeById(int id)
        {
            var dbRecipe = _recipeRepository.GetRecipeById(id);
            var recipe = Mapper.Map<Recipe>(dbRecipe);
            return recipe;
        }
        public Recipe GetRecipeByName(string name)
        {
            var dbRecipe = _recipeRepository.GetRecipeByName(name);
            var recipe = Mapper.Map<Recipe>(dbRecipe);
            return recipe;
        }
        public IEnumerable<Recipe> GetAll()
        {
            var dbRecipes = _recipeRepository.GetRecipes();
            var recipes = dbRecipes.ProjectTo<Recipe>();
            return recipes;
        }

        public SearchResponse SearchRecipes(SearchRequest searchRequest)
        {
            var response = new SearchResponse();

            if (searchRequest == null)
                searchRequest = new SearchRequest();

            var validationResult = new SearchRequestValidator().Validate(searchRequest);
            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            var dbRecipes = _recipeRepository.GetRecipes();

            if (!string.IsNullOrEmpty(searchRequest.Name))
                dbRecipes = dbRecipes.Where(x => x.Name.ToLower().StartsWith(searchRequest.Name.ToLower()));

            if (searchRequest.IsDone)
                dbRecipes = dbRecipes.Where(x => x.IsDone);

            if (searchRequest.IsFavorite)
                dbRecipes = dbRecipes.Where(x => x.IsFavorite);

            var recipes = dbRecipes.ProjectTo<Recipe>();
            response.Recipes = recipes;

            return response;
        }

          public RecipeResponse Create(RecipeRequest recipe)
        {
            var response = new RecipeResponse();

            if (recipe == null)
                recipe = new RecipeRequest();

            var validationResult = new RecipeRequestValidator().Validate(recipe);
            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            var existingRecipe = _recipeRepository.GetRecipeByName(recipe.Name);
            if (existingRecipe != null)
            {
                response.IsSuccessful = false;
                response.Errors.Add("Recipe already exists");
                return response;
            }

            var dataRecipe = new Data.Recipe
            {

                Name = recipe.Name,
                Description = recipe.Description,
                IsDone = recipe.IsDone,
                IsFavorite = recipe.IsFavorite,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            AddIngredients(dataRecipe, recipe, isNewRecipe: true);

            response.Recipe = Mapper.Map<Recipe>(_recipeRepository.Save(dataRecipe));
            return response;
        }
        public RecipeResponse Update(string name, RecipeRequest recipe)
        {
            var response = new RecipeResponse();

            if (recipe == null)
                recipe = new RecipeRequest();

            var validator = new RecipeRequestValidator();
            var validationResult = validator.Validate(recipe);
            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            var dataRecipe = _recipeRepository.GetRecipeByName(name);
            if (dataRecipe == null)
            {
                response.IsSuccessful = false;
                response.Errors.Add("This recipe does not exist");
                return response;
            }

            dataRecipe.Name = recipe.Name;
            dataRecipe.Description = recipe.Description;
            dataRecipe.IsDone = recipe.IsDone;
            dataRecipe.IsFavorite = recipe.IsFavorite;
            dataRecipe.DateModified = DateTime.Now;

            // var dbRecipeIngredients = _ingredientRepository.GetRecipeIngredients();
            //if (dataRecipe.Id !=0)
            //    dbRecipeIngredients = dbRecipeIngredients.Where(x => x.RecipeId.Equals(dataRecipe.Id));

            // foreach (var recipeIngredient in dbRecipeIngredients)
            //foreach (var recipeIngredient in dataRecipe.RecipeIngredients)
            //{
            //    _ingredientRepository.Remove(recipeIngredient.Ingredient.Name);
            //   //_ingredientRepository.Remove(recipeIngredient.RecipeId);
            //}

            AddIngredients(dataRecipe, recipe, isNewRecipe: false);
            _recipeRepository.Save(dataRecipe);

            response.Recipe = Mapper.Map<Recipe>(dataRecipe);
            return response;
        }

        public void AddIngredients(Data.Recipe dataRecipe, RecipeRequest recipe, bool isNewRecipe)
        {
            foreach (var recipeIngredient in recipe.Ingredients)
            {
                var dataIngredient = _ingredientRepository.GetIngredient(recipeIngredient.Name);
                if (dataIngredient == null)
                {
                    dataIngredient = new Data.Ingredient()
                    {
                        Name = recipeIngredient.Name,
                        Measurement = recipeIngredient.Measurement.ToString(),
                        DateCreated = DateTime.Now,

                    };
                }

                dataRecipe.RecipeIngredients.Add(new Data.RecipeIngredients
                {
                    Recipe = isNewRecipe ? dataRecipe : null,
                    Ingredient = dataIngredient.Id == 0 ? dataIngredient : null,
                    IngredientId = dataIngredient.Id,
                    Quantity = recipeIngredient.Quantity
                });
            }
        }

        public void Remove(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;

            _recipeRepository.Remove(name);
        }

        public IEnumerable<Ingredient> GetIngredients()
        {
            var dbIngredients = _ingredientRepository.GetIngredients();
            var ingredients = Mapper.Map<IEnumerable<Ingredient>>(dbIngredients);
            return ingredients;
        }
        public IEnumerable<Ingredient> SearchIngredients(string term)
        {
            var dbIngredients = _ingredientRepository.GetIngredients();
            dbIngredients = dbIngredients.Where(x => x.Name.ToLower().StartsWith(term.ToLower()));

            var ingredients = Mapper.Map<IEnumerable<Ingredient>>(dbIngredients);
            return ingredients;
        }
        public Ingredient GetIngredient(string name)
        {
            var dbIngredient = _ingredientRepository.GetIngredient(name);
            var ingredient = Mapper.Map<Ingredient>(dbIngredient);
            return ingredient;
        }


    }
}
