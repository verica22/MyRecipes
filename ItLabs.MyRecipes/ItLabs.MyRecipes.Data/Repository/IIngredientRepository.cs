using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.MyRecipes.Data.Repository
{
   public interface IIngredientRepository
    {

        void Save(Ingredient ingredient);
        void Remove(string name);
        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);
    }
}
