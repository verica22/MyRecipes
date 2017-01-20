﻿using FluentValidation;
using ItLabs.MyRecipes.Core.Requests;

namespace ItLabs.MyRecipes.Domain.Validations
{
    class SearchValidator : AbstractValidator<SearchRequest>
    {
        public SearchValidator()
        {
            RuleFor(x => x.Name)
               .Length(1, 50)
               .WithMessage("Recipe Name must be at least 4 characters")
               .Matches("^[a-zA-Z ']*$")
               .WithMessage("Recipe Name must contain characters and spaces only");

            RuleFor(x => x.page)
                .InclusiveBetween(1, 20)
                .WithMessage("Alowed pages between 1 and 20");

            RuleFor(x => x.pageSize)
               .InclusiveBetween(1, 10)
               .WithMessage("Page size is alowed between 1 and 10");

        }
    }
}
