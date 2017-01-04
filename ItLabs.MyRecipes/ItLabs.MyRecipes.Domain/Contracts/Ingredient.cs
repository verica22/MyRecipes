using System.Collections.Generic;

namespace ItLabs.MyRecipes.Domain
{
    public class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new List<RecipeIngredients>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Measurement { get; set; }

        public virtual List<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
