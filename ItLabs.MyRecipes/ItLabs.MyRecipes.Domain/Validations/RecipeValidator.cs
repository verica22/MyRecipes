using FluentValidation;
using ItLabs.MyRecipes.Data;
using System.Linq;

//todo
//uncomment this and use it
//add notnull check
//add call for unique name

//extend this with additional recipe ingredient checks for name, ingredinet name, measuremt

namespace ItLabs.MyRecipes.Domain.Validations
{
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Recipe Name is required")
                .Length(4, 100)
                .WithMessage("Recipe Name must be at least 4 characters")
                .Must(IsRecipeNameUnique)
                .WithMessage("This Recipe name already exist");

            RuleFor(x => x.RecipeIngredients)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please add ingredients");

            //RuleFor(x => x.RecipeIngredients.All<RecipeIngredients>)
            //    .NotNull()
            //    .NotEmpty()
            //    .WithMessage("Please add ingredients");
        }

        //use repository call here 
        private bool IsRecipeNameUnique(Recipe recipe, string name)
        {
            bool isUnique = false;
            Data.Recipe recipeName;
            using (RecipeDBContext db = new RecipeDBContext())
            {
                recipeName = db.Recipes.FirstOrDefault(x => x.Name == name);
            }
            if (recipeName == null)
            {
                isUnique = true;
            }
            else
            {
                isUnique = recipeName.Id == recipe.Id;
            }
            return isUnique;
        }

    }

}