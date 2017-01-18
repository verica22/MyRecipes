using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItLabs.MyRecipes.Data
{
    public class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new List<RecipeIngredients>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Measurement { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public virtual ICollection<RecipeIngredients> RecipeIngredients { get; set; }

        
    }
}
