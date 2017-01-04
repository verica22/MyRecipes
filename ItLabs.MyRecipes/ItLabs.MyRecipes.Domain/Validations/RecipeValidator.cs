using FluentValidation;


namespace ItLabs.MyRecipes.Domain.Validations
{
    public class FluentRecipeValidator : AbstractValidator<Recipe>
    {
        public FluentRecipeValidator()
        {
            //RuleFor(x => x.Name).NotEmpty().WithMessage("Recipe Name is required");
            //RuleFor(x => x.Name).NotEmpty().Length(4, 100).WithMessage("Must be atleast 4 characters");

            //RuleFor(x => x.RecipeIngredients).NotEmpty().WithMessage("Please add ingredients");

        }
        
    }
}