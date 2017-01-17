using FluentValidation;
using ItLabs.MyRecipes.Data;
using ItLabs.MyRecipes.Data.Repository;
using System.Linq;

namespace ItLabs.MyRecipes.Core.Validations
{

    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public IRecipeRepository _recipeRepository { get; set; }


        public RecipeValidator(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;

        }
        public RecipeValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Recipe Name is required")
                .Length(4, 100)
                .WithMessage("Recipe Name must be at least 4 characters");

            RuleFor(x => x.Name).Must(IsRecipeNameUnique)
                .WithMessage("This Recipe name already exist");

            RuleFor(x => x.RecipeIngredients)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please add ingredients");

        }
        public bool IsRecipeNameUnique(string name)
        {
            bool isUnique = false;
            var recipe = _recipeRepository.GetRecipeByName(name);
            if (recipe == null)
                { isUnique = true; }
            else
                { isUnique = false; }
            return isUnique;
        }
        //use repository call here 
        //private bool IsRecipeNameUnique(Recipe recipe, string name)
        //{
        //    //bool isUnique = false;
        //    //Data.Recipe recipeName;
        //    //using (RecipeDBContext db = new RecipeDBContext())
        //    //{
        //    //    recipeName = db.Recipes.FirstOrDefault(x => x.Name == name);
        //    //}
        //    //if (recipeName == null)
        //    //{
        //    //    isUnique = true;
        //    //}
        //    //else
        //    //{
        //    //    isUnique = recipeName.Id == recipe.Id;
        //    //}
        //    return isUnique;


        //    //bool isUnique = _recipeRepository.IsRecipeNameUnique(recipe, name);
        //    //return isUnique;
        //}

    }

}