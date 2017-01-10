using System.Collections.Generic;

namespace ItLabs.MyRecipes.Data.Repository
{
    //todo add new Ingredients repository
    //do we need Update? Use Save
   public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetRecipes();
        Recipe GetRecipe(int id);
        IEnumerable<Recipe> Search(string name, bool isDone, bool isFavourite, int? page);

        void Save(Recipe recipe);
        void Remove(int id);

        //bool IsRecipeNameUnique(string name);
        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);

    }
}
