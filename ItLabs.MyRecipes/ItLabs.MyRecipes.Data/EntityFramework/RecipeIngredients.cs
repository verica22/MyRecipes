using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItLabs.MyRecipes.Data
{
    public class RecipeIngredients
    {
        [Key,Column(Order=0)]
        public int RecipeId { get; set; }
        [Key,Column(Order = 1)]
        public int IngredientId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
       
        public int Quantity { get; set; }
    }
}
