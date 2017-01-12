using System.Collections.Generic;
using ItLabs.MyRecipes.Data.Repository;
using AutoMapper;
using System.Linq;
using ItLabs.MyRecipes.Core.Validations;
using ItLabs.MyRecipes.Core.Responses;
using PagedList;
using AutoMapper.QueryableExtensions;

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

        public Recipe Get(int Id)
        {
            var dbRecipe = _recipeRepository.GetRecipe(Id);
            var recipe = Mapper.Map<Recipe>(dbRecipe);
            return recipe;
        }

        public IPagedList<Recipe> Search(string name, bool isDone, bool isFavourite, int page, int pageSize = Core.Constants.DefaultPageSize)
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

        public ResponseBase SaveRecipe(Recipe recipe)
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
                dataRecipe.Name = recipe.Name;
                dataRecipe.Description = recipe.Description;
                dataRecipe.IsDone = recipe.IsDone;
                dataRecipe.IsFavorite = recipe.IsFavorite;
            }

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

            _recipeRepository.Save(dataRecipe);
            return response;
        }


        public void Remove(int id)
        {
            if (id == 0)
                return;

            _recipeRepository.Remove(id);
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

            //dbIngredients= dbIngredients.Where(x => x.Name.ToLower().StartsWith(term.ToLower()))
            //    .Select(e => e.Name).Distinct().ToList();

            var ingredients = Mapper.Map<IEnumerable<Ingredient>>(dbIngredients);
            return ingredients;
        }
        public Ingredient GetIngredient(string name)
        {
            var dbIngredients = _ingredientRepository.GetIngredients();
            var ingredients = Mapper.Map<Ingredient>(dbIngredients);
            return ingredients;
        }
    }
}
