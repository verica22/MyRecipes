using FluentValidation;


namespace ItLabs.MyRecipes.Domain.Validations
{
    class FluentIngredientValidator : AbstractValidator<Ingredient>
    {
        public FluentIngredientValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ingredient Name is required");
            RuleFor(x => x.Measurement).NotEmpty().WithMessage("Measurement is required");

        }
    }
}