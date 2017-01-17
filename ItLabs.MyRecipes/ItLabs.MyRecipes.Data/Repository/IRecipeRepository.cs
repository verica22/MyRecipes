using System.Collections.Generic;
using System.Linq;

namespace ItLabs.MyRecipes.Data.Repository
{
     public interface IRecipeRepository
    {
        IQueryable<Recipe> GetRecipes();
        Recipe GetRecipeByName(string name);
        Recipe GetRecipe(int id);
        void Save(Recipe recipe);
        void Remove(int id);
        bool IsRecipeNameUnique(string name);
        
    }
}
