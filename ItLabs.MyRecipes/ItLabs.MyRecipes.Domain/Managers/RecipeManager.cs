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
       
        public SearchResponse SearchRecipes(SearchRequest search)
         {
            var response = new SearchResponse();
            var validationResult = new SearchValidator().Validate(search);
            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                           return response;
            }

            var dbRecipes = _recipeRepository.GetRecipes();

            if (!string.IsNullOrEmpty(search.Name))
                dbRecipes = dbRecipes.Where(x => x.Name.ToLower().StartsWith(search.Name.ToLower()));

            if (search.IsDone)
                dbRecipes = dbRecipes.Where(x => x.IsDone);

            if (search.IsFavorite)
                dbRecipes = dbRecipes.Where(x => x.IsFavorite);

            var recipes = dbRecipes.ProjectTo<Recipe>();
            
            response.Recipes = recipes;

           // return recipes.OrderBy(x => x.Name).ToPagedList(search.page, search.pageSize);
            return response;
        }

        public RecipeResponse Create(RecipeRequest recipe)
        {
            var response = new RecipeResponse();
            var dbrecipe = Mapper.Map<Recipe>(recipe);
            var validationResult = new RecipeValidator().Validate(dbrecipe);
            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }
            var existingRecipe = _recipeRepository.GetRecipeByName(dbrecipe.Name);
            if(existingRecipe != null)
            {
                response.IsSuccessful = false;
                response.Errors.Add("Recipe already exists");
                return response;
            }
             DateTime time = DateTime.Now;
            string format = "yyyy-MM-dd HH:MM:ss";
            Data.Recipe dataRecipe = new Data.Recipe
            {

                Name = recipe.Name,
                Description = recipe.Description,
                IsDone = recipe.IsDone,
                IsFavorite = recipe.IsFavorite,
                DateCreated = time,//.ToString(format),
                DateModified = null
            };

            AddIngredients(dataRecipe, recipe, isNewRecipe: true);

            response.Recipe = Mapper.Map<Recipe>(_recipeRepository.Save(dataRecipe));
            return response;
        }
        public ResponseBase Update(string name,RecipeRequest recipe)
        {
            var response = new ResponseBase();

            var validator = new RecipeValidator();
            var dbrecipe = Mapper.Map<Recipe>(recipe);
            var validationResult = validator.Validate(dbrecipe);

            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            Data.Recipe dataRecipe = _recipeRepository.GetRecipeByName(name);
                dataRecipe.Name = recipe.Name;
                dataRecipe.Description = recipe.Description;
                dataRecipe.IsDone = recipe.IsDone;
                dataRecipe.IsFavorite = recipe.IsFavorite;
                dataRecipe.DateModified = DateTime.Now;

                AddIngredients(dataRecipe, recipe, isNewRecipe: false);
                _recipeRepository.Save(dataRecipe);
            
           
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
