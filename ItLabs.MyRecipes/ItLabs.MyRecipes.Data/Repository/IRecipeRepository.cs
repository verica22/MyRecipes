using System.Linq;

namespace ItLabs.MyRecipes.Data.Repository
{
     public interface IRecipeRepository
    {
        IQueryable<Recipe> GetRecipes();
        Recipe GetRecipe(int id);
        void Save(Recipe recipe);
        void Remove(int id);
        bool IsRecipeNameUnique(Recipe recipe, string name);

       
    }
}
