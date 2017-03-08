using FluentValidation;
using ItLabs.MyRecipes.Core.Requests;

namespace ItLabs.MyRecipes.Domain.Validations
{
    class SearchRequestValidator : AbstractValidator<SearchRequest>
    {
        public SearchRequestValidator()
        {
            RuleFor(x => x.Name)
               .Matches("^[a-zA-Z ']*$")
               .WithMessage("Recipe Name must contain characters and spaces only");

            RuleFor(x => x.Page)
                .InclusiveBetween(1, 20)
                .WithMessage("Alowed pages between 1 and 20");

            RuleFor(x => x.PageSize)
               .InclusiveBetween(1, 10)
               .WithMessage("Page size is alowed between 1 and 10");

        }
    }
}
