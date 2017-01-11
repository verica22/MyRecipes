using System.Collections.Generic;

namespace ItLabs.MyRecipes.Data.Repository
{
     public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipe(int id);
        IEnumerable<Recipe> Search(string name, bool isDone, bool isFavourite, int? page);

        void Save(Recipe recipe);
        void Remove(int id);

        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);

    }
}
