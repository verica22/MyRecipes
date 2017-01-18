using ItLabs.MyRecipes.Core.Requests;
using ItLabs.MyRecipes.Core.Responses;
using PagedList;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.Core
{
    public interface IRecipeManager
    {
        Recipe GetRecipeById(int id);
        Recipe GetRecipeByName(string name);
        IEnumerable<Recipe> GetAll();
        
        SearchResponse SearchRecipes(SearchRequest search);
        RecipeResponse Create(RecipeRequest recipe);
        ResponseBase Update(string name,RecipeRequest recipe);
        void Remove(string name);
        
        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);
        IEnumerable<Ingredient> SearchIngredients(string name);
    }
}
