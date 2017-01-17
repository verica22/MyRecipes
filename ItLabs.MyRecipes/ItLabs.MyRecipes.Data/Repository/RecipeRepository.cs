using ItLabs.MyRecipes.Data;
using System.Data.Entity;
using System.Linq;
using System;
using System.Collections.Generic;

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
        public Recipe GetRecipe(int id)
        {
            var recipe = _dbContext.Recipes.SingleOrDefault(x => x.Id == id);
            return recipe;
        }

        public void Save(Recipe recipe)
        {
            if (recipe == null)
                return;

            if (recipe.Id == 0)
            {
                _dbContext.Recipes.Add(recipe);
            }
            else
            {
                _dbContext.Entry(recipe).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            if (id == 0)
                return;

            var recipe = GetRecipe(id);

            if (recipe == null)
                return;
           
            _dbContext.Recipes.Remove(recipe);
            _dbContext.SaveChanges();
            
        }
        public bool IsRecipeNameUnique(string name)
        {
            //var recipe = _dbContext.Recipes.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());
            //return (recipe == null);

            bool isUnique = false;
            Recipe recipeName;
            using (_dbContext)
            {
                recipeName = _dbContext.Recipes.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
            }
            if (recipeName == null)
            {
                isUnique = true;
            }
            else
            {
                //isUnique = recipeName.Id == recipe.Id;
                isUnique = false;
            }
            return isUnique;
        }

        
    }
}
