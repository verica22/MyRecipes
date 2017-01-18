using ItLabs.MyRecipes.Core.Requests;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.Core.Responses
{
    public class SearchResponse : ResponseBase
    {
         public IEnumerable<Recipe> Recipes { get; set; }
    }
}
