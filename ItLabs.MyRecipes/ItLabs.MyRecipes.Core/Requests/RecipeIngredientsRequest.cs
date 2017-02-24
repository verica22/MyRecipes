using ItLabs.MyRecipes.Core.Enums;

namespace ItLabs.MyRecipes.Core.Requests
{
   public class RecipeIngredientsRequest
    {
        public string IngredientName { get; set; }
        public Measurement Measurement { get; set; }

        public int Quantity { get; set; }
    }
}
