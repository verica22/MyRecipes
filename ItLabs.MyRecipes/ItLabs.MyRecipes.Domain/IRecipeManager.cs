using ItLabs.MyRecipes.Domain.Responses;
using PagedList;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public interface IRecipeManager
    {
        Recipe Get(int Id);
        IPagedList<Recipe> Search(string name, bool isDone, bool isFavourite, int page, int pageSize = Core.Constants.DefaultPageSize);

        ResponseBase SaveRecipe(Recipe recipe);
        void Remove(int Id);

        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);
    }
}
