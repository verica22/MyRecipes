using ItLabs.MyRecipes.Domain.Enums;

namespace ItLabs.MyRecipes.Domain
{
    public class RecipeIngredients
    {
        public int RecipeId { get; set; }
       
        public int IngredientsId { get; set; }

        public string RecipeName { get; set; }
        public string IngredientName { get; set; }
        public string IngredientMeasurement { get; set; }

       
        public int Quantity { get; set; }

       }
}
