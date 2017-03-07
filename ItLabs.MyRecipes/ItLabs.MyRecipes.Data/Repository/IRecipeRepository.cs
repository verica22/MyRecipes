using System.Collections.Generic;
using System.Linq;

namespace ItLabs.MyRecipes.Data.Repository
{
     public interface IRecipeRepository
    {
        IQueryable<Recipe> GetRecipes();
        Recipe GetRecipeByName(string name);
        Recipe GetRecipeById(int id);
        Recipe Save(Recipe recipe);
        void Remove(string name);
            
    }
}
