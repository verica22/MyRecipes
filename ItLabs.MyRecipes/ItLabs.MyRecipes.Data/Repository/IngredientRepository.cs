using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ItLabs.MyRecipes.Data.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly RecipeDBContext _dbContext;

        public IngredientRepository()
        {
            _dbContext = new RecipeDBContext();
        }
        public IEnumerable<Ingredient> GetIngredients()
        {
            return _dbContext.Ingredients.ToList();
        }
      
        public Ingredient GetIngredient(string name)
        {
            var ingredient = _dbContext.Ingredients.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());
            return ingredient;
        }
        public void Save(Ingredient ingredient)
        {
            if (ingredient == null)
                return;

            if (ingredient.Id == 0)
            {
                _dbContext.Ingredients.Add(ingredient);
            }
            else
            {
                _dbContext.Entry(ingredient).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }
        public IQueryable<RecipeIngredients> GetRecipeIngredient(int id)
        {
            var recipeIngredients = _dbContext.RecipeIngredients.Where(x => x.RecipeId == id);
            return recipeIngredients;
        }
        public void Remove(int id)
        {
            if (id == 0)
                return;

            var recipeIngredient = GetRecipeIngredient(id);

            if (recipeIngredient == null)
                return;
            foreach (var ingredient in recipeIngredient.ToList())
            {
                _dbContext.RecipeIngredients.Remove(ingredient);
                _dbContext.SaveChanges();

            }
        }
       
    }
}
