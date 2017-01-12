using System;
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
        //public IEnumerable<Ingredient> SearchIngredients(string name)
        //{
        //    throw new NotImplementedException();
        //}

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
        public void Remove(string name)
        {
            if (string.IsNullOrEmpty(name))
                return;

            var ingredient = GetIngredient(name);

            if (ingredient == null)
                return;

            _dbContext.Ingredients.Remove(ingredient);
            _dbContext.SaveChanges();
        }

       
    }
}
