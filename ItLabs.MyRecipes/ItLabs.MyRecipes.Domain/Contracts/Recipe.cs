using System.Collections.Generic;

namespace ItLabs.MyRecipes.Core
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsFavorite { get; set; }

        public virtual IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
