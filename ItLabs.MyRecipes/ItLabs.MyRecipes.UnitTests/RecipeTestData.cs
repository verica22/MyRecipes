using ItLabs.MyRecipes.Core;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.UnitTests
{
    public class RecipeTestData
    {
        public List<Recipe> GetTestRecipes()
        {
            var testRecipes = new List<Recipe>();
            testRecipes.Add(new Recipe { Id = 1, Name = "Recipe1", IsDone = false, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Recipe { Id = 2, Name = "Recipe2", IsDone = false, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Recipe { Id = 3, Name = "Recipe3", IsDone = false, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Recipe { Id = 4, Name = "Recipe4", IsDone = false, IsFavorite = false, Description = "gvdsfgdsfgdf" });

            return testRecipes;
        }


    }
}
