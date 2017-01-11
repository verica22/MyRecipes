using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItLabs.MyRecipes.Data.Repository
{
   public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetIngredients();
        Ingredient GetIngredient(string name);
        void Save(Ingredient ingredient);
        void Remove(string name);
       
    }
}
