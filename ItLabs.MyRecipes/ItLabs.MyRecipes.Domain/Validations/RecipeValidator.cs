using System;
using FluentValidation;
using ItLabs.MyRecipes.Core.Requests;

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
                .WithMessage("Recipe Name must be at least 4 characters")
                .Matches("^[a-zA-Z ']*$")
                .WithMessage("Recipe Name must contain characters and spaces only");

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .Length(10, 1000)
                .WithMessage("Recipe Description must be between 10 and 1000 characters");

         }


    }
}