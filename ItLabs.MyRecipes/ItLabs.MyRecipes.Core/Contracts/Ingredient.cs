using ItLabs.MyRecipes.Core.Enums;
using System;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.Core
{
    public class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new List<RecipeIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Measurement Measurement { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public virtual IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
