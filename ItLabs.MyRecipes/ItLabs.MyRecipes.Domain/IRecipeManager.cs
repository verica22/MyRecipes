using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public interface IRecipeManager
    {
        IEnumerable<Recipe> GetRecipes();
        void Save(Recipe recipe);
        void Remove(int Id);
        Recipe FindById(int Id);
        void Edit(Recipe recipe);
        IEnumerable<Recipe> SearchRecipes(string name, bool isDone, bool isFavourite);
        IEnumerable<Ingredient> GetIngredients();
      
    }
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
    }
}
