using ItLabs.MyRecipes.Domain.Responses;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public interface IRecipeManager
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe Get(int Id);
        IEnumerable<Recipe> Search(string name, bool isDone, bool isFavourite);

        ResponseBase SaveRecipe(Recipe recipe);
        void Remove(int Id);
        void Update(Recipe recipe);

        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);
    }
}
