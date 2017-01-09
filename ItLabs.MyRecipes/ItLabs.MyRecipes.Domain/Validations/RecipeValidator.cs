using FluentValidation;
using ItLabs.MyRecipes.Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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
            RuleFor(x => x.RecipeIngredients).NotNull().NotEmpty().WithMessage("Please add ingredients");
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Recipe Name is required");
            //RuleFor(x => x.Name).Must(IsRecipeNameUnique(name)).WithMessage("This Email id has already been registered"); ;

            // RuleFor(x => x.Name).IsUnique(recipes).WithMessage("Name must be unique");
            //      RuleFor(x => x.Name).SetValidator(new UniquePropertyValidator<RecipeDBContext>(Recipe.).WithMessage("This Recipe has already been registered");
            //      RuleFor(player => player.Name).SetValidator(new UniqueValidator<Player>(players))
            //.WithMessage("Name must be unique");

            //RuleFor(x => x.RecipeIngredients.All<Ingredient>).NotNull().NotEmpty().WithMessage("Please add ingredients");

        }
       
    }
 //   public static IRuleBuilderOptions<TItem, TProperty> IsUnique<TItem, TProperty>(
 //this IRuleBuilder<TItem, TProperty> ruleBuilder, IEnumerable<TItem> items)
 //  where TItem : class
 //   {
 //       return ruleBuilder.SetValidator(new UniqueValidator<TItem>(items));
 //   }
}