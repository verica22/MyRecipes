using ItLabs.MyRecipes.Core.Responses;
using PagedList;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.Core
{
    public interface IRecipeManager
    {
        Recipe Get(int Id);
        IPagedList<Recipe> Search(string name, bool isDone, bool isFavourite, int page, int pageSize = Core.Constants.DefaultPageSize);

        ResponseBase SaveRecipe(Recipe recipe);
        void Remove(int Id);

        IEnumerable<Ingredient> GetIngredients();
        IEnumerable<Ingredient> SearchIngredients(string name);
        Ingredient GetIngredient(string name);
    }
}
