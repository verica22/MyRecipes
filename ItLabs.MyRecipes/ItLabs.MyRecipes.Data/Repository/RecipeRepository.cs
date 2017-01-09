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
        public IEnumerable<Recipe> Search(string name, bool isDone, bool isFavourite)
        {

            var recipes = _dbContext.Recipes.AsQueryable();

            //add total
            var total = recipes.Count();

            if (!string.IsNullOrEmpty(name))
                recipes = recipes.Where(x => x.Name.ToLower().StartsWith(name.ToLower()));

            if (isDone)
                recipes = recipes.Where(x => x.IsDone);

            if (isFavourite)
                recipes = recipes.Where(x => x.IsFavorite).OrderBy(x => x.Id).Skip((1 - 1) * pageSize).Take(pageSize);

            //add paging - skip take etc
            //          var queryResultPage = recipes
            //.Skip(pageSize * pageNumber)
            //.Take(pageSize);

            //var pagedQuery =
            //  from e in recipes.Skip(pageSize * 1).Take(pageSize)
            //  select new
            //  {
            //      Count = recipes.Count(),
            //      Entity = e
            //  };
            return recipes.ToList();//.ToPagedList(page, PageSize);

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

        //for this you will need the id (if 0 its new, work on the condition for update and creatae)
        public bool IsRecipeNameUnique(string name, int? id)
        {
            var recipe = _dbContext.Recipes.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());

            return (recipe == null);
        }

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
