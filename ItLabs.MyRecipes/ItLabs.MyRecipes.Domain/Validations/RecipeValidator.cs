using FluentValidation;

namespace ItLabs.MyRecipes.Core.Validations
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
                .WithMessage("Recipe Name must be at least 4 characters");

            RuleFor(x => x.RecipeIngredients)
                .NotNull()
                .NotEmpty()
                .WithMessage("Please add ingredients");
        }
    }
}