using ItLabs.MyRecipes.Core.Responses;
using PagedList;
using System.Collections.Generic;
using System.Linq;

namespace ItLabs.MyRecipes.Core
{
    public interface IRecipeManager
    {
        Recipe GetRecipeById(int id);
        Recipe GetRecipeByName(string name);
        IEnumerable<Recipe> GetAll();
        IPagedList<Recipe> SearchRecipes(string name, bool isDone, bool isFavourite, int page, int pageSize = Constants.DefaultPageSize);

        RecipeResponse Create(Recipe recipe);
        ResponseBase Update(Recipe recipe);
        void Remove(string name);
        
        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);
        IEnumerable<Ingredient> SearchIngredients(string name);
    }
}
