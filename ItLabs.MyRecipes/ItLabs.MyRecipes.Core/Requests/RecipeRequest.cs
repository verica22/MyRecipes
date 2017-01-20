using System.Collections.Generic;

namespace ItLabs.MyRecipes.Core.Requests
{
    public class RecipeRequest
    {
        public RecipeRequest()
        {
            Ingredients = new List<IngredientRequest>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsFavorite { get; set; }
        
        public virtual IEnumerable<IngredientRequest> Ingredients { get; set; }
    }
}
