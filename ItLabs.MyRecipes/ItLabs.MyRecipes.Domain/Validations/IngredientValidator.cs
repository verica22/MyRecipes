using FluentValidation;

namespace ItLabs.MyRecipes.Core.Validations
{
    public class IngredientValidator : AbstractValidator<Ingredient>
    {
        public IngredientValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Ingredient Name is required");
            RuleFor(x => x.Measurement).NotNull().NotEmpty().WithMessage("Measurement is required");
        }
    }
}