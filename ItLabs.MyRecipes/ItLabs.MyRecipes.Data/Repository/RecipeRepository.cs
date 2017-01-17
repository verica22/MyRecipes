using System.Data.Entity;
using System.Linq;

namespace ItLabs.MyRecipes.Data.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeDBContext _dbContext;

        public RecipeRepository()
        {
            _dbContext = new RecipeDBContext();
        }
      
        public IQueryable<Recipe> GetRecipes()
        {
            return _dbContext.Recipes;
        }
        public Recipe GetRecipeByName(string name)
        {
            var recipe = _dbContext.Recipes.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());
            return recipe;
        }
        public Recipe GetRecipeById(int id)
        {
            var recipe = _dbContext.Recipes.SingleOrDefault(x => x.Id == id);
            return recipe;
        }

        public Recipe Save(Recipe recipe)
        {
            if (recipe == null)
                return null;

            if (recipe.Id == 0)
            {
                recipe = _dbContext.Recipes.Add(recipe);
            }
            else
            {
                _dbContext.Entry(recipe).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
            return recipe;
        }

        public void Remove(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;

            var recipe = GetRecipeByName(name);

            if (recipe == null)
                return;
           
            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
        }
    }
}
