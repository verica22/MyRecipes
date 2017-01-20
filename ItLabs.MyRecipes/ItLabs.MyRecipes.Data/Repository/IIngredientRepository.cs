using System.Collections.Generic;
using System.Linq;

namespace ItLabs.MyRecipes.Data.Repository
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);
        void Save(Ingredient ingredient);
        void Remove(string name);
        // void Remove(int id);
        IQueryable<RecipeIngredients> GetRecipeIngredients();

        //RecipeIngredients GetRecipeIngredient(int id);


    }
}
