using FluentValidation;
using ItLabs.MyRecipes.Data;
using System.Linq;
using ItLabs.MyRecipes.Data.Repository;

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
                //.Must(IsRecipeNameUnique)
                //.WithMessage("This Recipe name already exist");

            RuleFor(x => x.RecipeIngredients)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please add ingredients");

       }

        //use repository call here 
        private bool IsRecipeNameUnique(Data.Recipe recipe, string name)
        {
            //bool isUnique = false;
            //Data.Recipe recipeName;
            //using (RecipeDBContext db = new RecipeDBContext())
            //{
            //    recipeName = db.Recipes.FirstOrDefault(x => x.Name == name);
            //}
            //if (recipeName == null)
            //{
            //    isUnique = true;
            //}
            //else
            //{
            //    isUnique = recipeName.Id == recipe.Id;
            //}
            //return isUnique;


            bool isUnique = _recipeRepository.IsRecipeNameUnique(recipe, name);
            return isUnique;
        }

    }

}