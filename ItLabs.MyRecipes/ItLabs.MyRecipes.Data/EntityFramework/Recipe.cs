using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.MyRecipes.Data
{
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredients>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
