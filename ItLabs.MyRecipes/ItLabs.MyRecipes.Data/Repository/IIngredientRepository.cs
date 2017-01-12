using System.Collections.Generic;

namespace ItLabs.MyRecipes.Data.Repository
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetIngredients();
        //IEnumerable<Ingredient> SearchIngredients(string name);
        Ingredient GetIngredient(string name);
        void Save(Ingredient ingredient);
        void Remove(string name);
    }
}
