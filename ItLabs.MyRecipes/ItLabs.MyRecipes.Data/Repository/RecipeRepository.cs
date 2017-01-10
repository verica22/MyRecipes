using System.Collections.Generic;
//todo
//for include purposes
using System.Data.Entity;
using System.Linq;


namespace ItLabs.MyRecipes.Data.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
             public const int pageSize = 2;
        //   int pageNumber = (page ?? 1);

        private readonly RecipeDBContext _dbContext;



        public RecipeRepository()
        {
            _dbContext = new RecipeDBContext();
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return _dbContext.Recipes.ToList();
        }

        public Recipe GetRecipe(int id)
        {
            var recipe = _dbContext.Recipes.SingleOrDefault(x => x.Id == id);
            return recipe;
        }

        //add new class/request for this containing pageIndex, pageSize and filter below
        //out parameter total
        public IEnumerable<Recipe> Search(string name, bool isDone, bool isFavourite,int? page)
        {
          var recipes = _dbContext.Recipes.AsQueryable();
             //add total
            var total = recipes.Count();

            if (!string.IsNullOrEmpty(name))
                recipes = recipes.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));

            if (isDone)
                recipes = recipes.Where(x => x.IsDone);

            if (isFavourite)
                recipes = recipes.Where(x => x.IsFavorite);

            //add paging - skip take etc
            return recipes.OrderBy(x => x.Id)
                .Skip((page ?? 0) * pageSize)
                .Take(pageSize)
                .ToList();
            //.ToPagedList(page, PageSize);

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

        // public bool IsRecipeNameUnique(string name)
        //{
        //    var recipe = _dbContext.Recipes.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());
        //    return (recipe == null);
        //}

        public IEnumerable<Ingredient> GetIngredients()
        {
            return _dbContext.Ingredients.ToList();
        }

        public Ingredient GetIngredient(string name)
        {
            var ingredient = _dbContext.Ingredients.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());
            return ingredient;
            //var ingredients = _dbContext.Ingredients.AsQueryable();

            //      if (!string.IsNullOrEmpty(name))
            //    ingredients = ingredients.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));

            //return ingredients.ToList();
        }
    }
}
