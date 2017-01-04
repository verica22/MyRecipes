using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.MyRecipes.Data
{
    public class Recipe
    {
        public Recipe()
        {
            this.RecipeIngredients = new HashSet<RecipeIngredients>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public bool Favorites { get; set; }

        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
