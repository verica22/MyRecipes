using System;
using System.Collections.Generic;
using System.Linq;

namespace ItLabs.MyRecipes.Data.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        RecipeDBContext db = new RecipeDBContext();
        public Recipe FindById(int Id)
        {
            var result = (from recipe in db.Recipes where recipe.Id == Id select recipe).FirstOrDefault();
            return result;
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return db.Recipes.ToList();
        }
        public IEnumerable<Recipe> SearchRecipes(string name, bool isDone, bool isFavourite)
        {
            if (name == "")
            {
                var recipes = db.Recipes.Where(r =>
                    (!isDone || r.Done) &&
                    (!isFavourite || r.Favorites));
                return recipes.ToList();
            }
            else
            {
                var recipes = db.Recipes.Where(r =>
                    (!isDone || r.Done) &&
                    (!isFavourite || r.Favorites) &&
                    r.Name.ToLower().Contains(name.ToLower()));
                return recipes.ToList();
            }
           
        }
        public void Remove(int Id)
        {
            Recipe recipe = db.Recipes.Find(Id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
        }


        public void Save(Recipe recipe)
        {
            
            if (recipe.Id == 0)
            {
               
                db.Recipes.Add(recipe);
               
            }
            else
            {
                db.Entry(recipe).State = System.Data.Entity.EntityState.Modified;
               
            }
            db.SaveChanges();

           
        }

        public void Edit(Recipe recipe)
        {

            db.Entry(recipe).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public bool UniqueRecipeName(string name)
        {
           
            var recipe = db.Recipes.Where(x => x.Name.ToLower() == name.ToLower()).SingleOrDefault();

            if (recipe == null) return true;
            return false;
        }


        public IEnumerable<Ingredient> GetIngredients()
        {
            return db.Ingredients.ToList();
        }

       


        //public GetIngredients(string term)
        //{

        //    List<string> ingredients;
        //    ingredients = db.Ingredients.Where(x => x.Name.StartsWith(term))
        //        .Select(e => e.Name).Distinct().ToList();

        //    return ingredients;
        //}

    }

}
