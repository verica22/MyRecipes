using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;
using AutoMapper;
using System.Linq;
using ItLabs.MyRecipes.Core.Validations;
using ItLabs.MyRecipes.Core.Responses;
using PagedList;
using AutoMapper.QueryableExtensions;
using System;

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

        //request for these parameters and validator for that request
        public IPagedList<Recipe> SearchRecipes(string name, bool isDone, bool isFavourite, int page, int pageSize = Constants.DefaultPageSize)
        {
            var dbRecipes = _recipeRepository.GetRecipes();

            if (!string.IsNullOrEmpty(name))
                dbRecipes = dbRecipes.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));

            if (isDone)
                dbRecipes = dbRecipes.Where(x => x.IsDone);

            if (isFavourite)
                dbRecipes = dbRecipes.Where(x => x.IsFavorite);

            var recipes = dbRecipes.ProjectTo<Recipe>();
            return recipes.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }

        public RecipeResponse Create(Recipe recipe)
        {
            var response = new RecipeResponse();

            var validationResult = new RecipeValidator().Validate(recipe);
            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            //check if recipe
            var existingRecipe = _recipeRepository.GetRecipeByName(recipe.Name);
            if(existingRecipe != null)
            {
                response.IsSuccessful = false;
                response.Errors.Add("Recipe already exists");
                return response;
            }

            Data.Recipe dataRecipe = new Data.Recipe
            {
                Name = recipe.Name,
                Description = recipe.Description,
                IsDone = recipe.IsDone,
                IsFavorite = recipe.IsFavorite
            };

            AddIngredients(dataRecipe, recipe);

            response.Recipe = Mapper.Map<Recipe>(_recipeRepository.Save(dataRecipe));
            return response;
        }
        public ResponseBase Update(Recipe recipe)
        {
            var response = new ResponseBase();

            var validator = new RecipeValidator();
            var validationResult = validator.Validate(recipe);

            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            Data.Recipe dataRecipe = _recipeRepository.GetRecipeById(recipe.Id);
            dataRecipe.Name = recipe.Name;
            dataRecipe.Description = recipe.Description;
            dataRecipe.IsDone = recipe.IsDone;
            dataRecipe.IsFavorite = recipe.IsFavorite;

            AddIngredients(dataRecipe, recipe);

            _recipeRepository.Save(dataRecipe);
            return response;
        }

        public void AddIngredients(Data.Recipe dataRecipe, Recipe recipe)
        {
            foreach (var recipeIngredient in recipe.RecipeIngredients)
            {
                var dataIngredient = _ingredientRepository.GetIngredient(recipeIngredient.IngredientName);
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
