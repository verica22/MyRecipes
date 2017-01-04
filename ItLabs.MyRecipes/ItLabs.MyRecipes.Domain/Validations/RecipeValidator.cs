using FluentValidation;
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
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Recipe Name is required");
            RuleFor(x => x.Name).Length(4, 100).WithMessage("Recipe Name must be at least 4 characters");
            RuleFor(x => x.RecipeIngredients).NotEmpty().WithMessage("Please add ingredients");
        }
    }
}