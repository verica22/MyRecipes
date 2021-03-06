using ItLabs.MyRecipes.Core.Requests;
using ItLabs.MyRecipes.Core.Responses;
// <copyright file="RecipeManagerTest.cs">Copyright ©  2016</copyright>

using System;
using ItLabs.MyRecipes.Core.Managers;
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

        [PexMethod]
        [PexAllowedException(typeof(NullReferenceException))]
        public SearchResponse SearchRecipes([PexAssumeUnderTest]RecipeManager target, SearchRequest searchRequest)
        {
            SearchResponse result = target.SearchRecipes(searchRequest);
            return result;
            // TODO: add assertions to method RecipeManagerTest.SearchRecipes(RecipeManager, SearchRequest)
        }
    }
}
