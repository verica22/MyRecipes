using ItLabs.MyRecipes.Core;
using System.Collections.Generic;
using System.Linq;

namespace ItLabs.MyRecipes.UnitTests
{
    public static class RecipeTestData
    {
        public static List<Recipe> GetRecipes()
        {
            var testRecipes = new List<Recipe>();
            testRecipes.Add(new Recipe { Id = 1, Name = "Recipe1", IsDone = false, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Recipe { Id = 2, Name = "Recipe2", IsDone = true, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Recipe { Id = 3, Name = "Recipe3", IsDone = false, IsFavorite = true, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Recipe { Id = 4, Name = "Recipe4", IsDone = true, IsFavorite = true, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Recipe { Id = 4, Name = "Chocolate Gravy", IsDone = false, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            return testRecipes;
        }
        public static List<Recipe> GetRecipe()
        {
            var testRecipes = new List<Recipe>();
            testRecipes.Add(new Recipe { Id = 4, Name = "Chocolate Gravy", IsDone = false, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            return testRecipes;
        }
        public static List<Recipe> GetDoneRecipe()
        {
            var testRecipes = new List<Recipe>();
            testRecipes.Add(new Recipe { Id = 2, Name = "Recipe2", IsDone = true, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Recipe { Id = 4, Name = "Recipe4", IsDone = true, IsFavorite = true, Description = "gvdsfgdsfgdf" });
            return testRecipes;
        }
        public static IQueryable<Data.Recipe> GetDataRecipes()
        {
            var testRecipes = new List<Data.Recipe>();
            testRecipes.Add(new Data.Recipe { Id = 1, Name = "Recipe1", IsDone = false, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Data.Recipe { Id = 2, Name = "Recipe2", IsDone = true, IsFavorite = false, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Data.Recipe { Id = 3, Name = "Recipe3", IsDone = false, IsFavorite = true, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Data.Recipe { Id = 4, Name = "Recipe4", IsDone = true, IsFavorite = true, Description = "gvdsfgdsfgdf" });
            testRecipes.Add(new Data.Recipe { Id = 4, Name = "Chocolate Gravy", IsDone = false, IsFavorite = false, Description = "gvdsfgdsfgdf" });

            return testRecipes.AsQueryable();
        }


    }
}
