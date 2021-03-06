using ItLabs.MyRecipes.Core.Requests;
using ItLabs.MyRecipes.Core.Responses;
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItLabs.MyRecipes.Core.Managers.Tests
{
    [TestClass]
    [PexClass(typeof(RecipeManager))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class RecipeManagerTest
    {
        [PexMethod(MaxBranches = 20000)]
        public SearchResponse SearchRecipes([PexAssumeUnderTest]RecipeManager target, SearchRequest searchRequest)
        {
            SearchResponse result = target.SearchRecipes(searchRequest);
            return result;
            // TODO: add assertions to method RecipeManagerTest.SearchRecipes(RecipeManager, SearchRequest)
        }
    }
}
