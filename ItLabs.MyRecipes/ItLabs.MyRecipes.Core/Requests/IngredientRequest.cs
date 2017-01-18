using ItLabs.MyRecipes.Core.Enums;

namespace ItLabs.MyRecipes.Core.Requests
{
   public class IngredientRequest
    {
        public string Name { get; set; }
        public Measurement Measurement { get; set; }

        public int Quantity { get; set; }
    }
}
