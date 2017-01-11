using ItLabs.MyRecipes.Domain.Enums;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new List<RecipeIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Measurement Measurement { get; set; }

        public virtual IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
