namespace ItLabs.MyRecipes.Domain
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        public string RecipeName { get; set; }
        public string IngredientName { get; set; }
        public string Measurement { get; set; }

        public int Quantity { get; set; }
    }
}
