using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItLabs.MyRecipes.Data.Repository;
using ItLabs.MyRecipes.Core.Responses;
using ItLabs.MyRecipes.Core.Requests;
//using NUnit.Framework;

namespace ItLabs.MyRecipes.Core.Managers.Tests
{

    //[TestFixture]
    public partial class RecipeManagerTest
    {
        // [Test]
        [TestMethod]
        public void can_search_recipe()
        {
            //ARRANGE
            RecipeManager recipeManager;
            recipeManager = new RecipeManager(null, null);

            var res = new SearchRequest();
            res.Name = "chocolate";
            res.IsDone = true;
            res.IsFavorite = true;
            res.Page = 1;
            res.PageSize = 5;

            //ACT
            var res2 = recipeManager.SearchRecipes(res);

            //ASSERT
            Assert.IsNotNull(res2);
        }

        [TestMethod]
        public void search_recipe_null()
        {
            //ARRANGE
            RecipeManager recipeManager;
            recipeManager = new RecipeManager(null, null);

            var res = new SearchRequest();
            res.Name = "";
            res.IsDone = true;
            res.IsFavorite = true;
            res.Page = 1;
            res.PageSize = 5;

            //ACT
            var searchResponse = recipeManager.SearchRecipes(res);

            //ASSERT
            Assert.IsNotNull(searchResponse);
        }

        [TestMethod]
        [PexGeneratedBy(typeof(RecipeManagerTest))]
        public void SearchRecipes()
        {
            RecipeManager recipeManager;
            SearchRequest searchRequest;
            SearchResponse searchResponse;
            recipeManager =
            new RecipeManager(null, null);
            searchRequest = new SearchRequest();

            searchRequest.Name = new string('\0', 51);
            searchRequest.IsDone = false;
            searchRequest.IsFavorite = false;

            searchResponse = SearchRecipes(recipeManager, searchRequest);
            NUnit.Framework.Assert.IsNotNull(searchResponse);
            NUnit.Framework.Assert.IsNull(searchResponse.Recipes);
            Assert.AreEqual<bool>(false, searchResponse.IsSuccessful);
            Assert.IsNotNull(((ResponseBase)searchResponse).Errors);
            Assert.AreEqual<int>(4, searchResponse.Errors.Capacity);
            Assert.AreEqual(2, ((ResponseBase)searchResponse).Errors.Count);
            Assert.IsNotNull((object)recipeManager);
            Assert.IsNull(recipeManager._recipeRepository);
            Assert.IsNull(recipeManager._ingredientRepository);
        }

        [TestMethod]
        [PexGeneratedBy(typeof(RecipeManagerTest))]
        [Microsoft.VisualStudio.TestTools.UnitTesting.Ignore]
        [PexDescription("the test state was: path bounds exceeded")]
        public void SearchRecipes01()
        {
            RecipeRepository recipeRepository;
            RecipeManager recipeManager;
            SearchResponse searchResponse;
            recipeRepository = new RecipeRepository();
            recipeManager = new RecipeManager
                                (recipeRepository, null);
            searchResponse = this.SearchRecipes(recipeManager, (SearchRequest)null);
        }

        [TestMethod]
        [PexGeneratedBy(typeof(RecipeManagerTest))]
        public void SearchRecipes677()
        {
            RecipeManager recipeManager;
            SearchRequest searchRequest;
            SearchResponse searchResponse;
            recipeManager =
              new RecipeManager((IRecipeRepository)null, (IIngredientRepository)null);
            searchRequest = new SearchRequest();
            searchRequest.Name = "";
            searchRequest.IsDone = true;
            searchRequest.IsFavorite = true;
            searchResponse = this.SearchRecipes(recipeManager, searchRequest);
            Assert.IsNotNull((object)searchResponse);
            Assert.IsNull(searchResponse.Recipes);
            Assert.AreEqual<bool>(false, ((ResponseBase)searchResponse).IsSuccessful);
            Assert.IsNotNull(((ResponseBase)searchResponse).Errors);
            Assert.AreEqual<int>(4, ((ResponseBase)searchResponse).Errors.Capacity);
            Assert.AreEqual<int>(1, ((ResponseBase)searchResponse).Errors.Count);
            Assert.IsNotNull((object)recipeManager);
            Assert.IsNull(recipeManager._recipeRepository);
            Assert.IsNull(recipeManager._ingredientRepository);
        }

        [TestMethod]
        [PexGeneratedBy(typeof(RecipeManagerTest))]
        [Ignore]
        [PexDescription("the test state was: duplicate path")]
        public void SearchRecipesThrowsNullReferenceException981()
        {
            RecipeManager recipeManager;
            SearchRequest searchRequest;
            SearchResponse searchResponse;
            recipeManager =
              new RecipeManager(null, (IIngredientRepository)null);
            searchRequest = new SearchRequest();
            searchRequest.Name = "  pPbd P HH \'";
            searchRequest.IsDone = false;
            searchRequest.IsFavorite = false;
            searchResponse = this.SearchRecipes(recipeManager, searchRequest);
        }

        [TestMethod]
        [PexGeneratedBy(typeof(RecipeManagerTest))]
        public void SearchRecipes2()
        {
            RecipeManager recipeManager;
            SearchRequest searchRequest;
            SearchResponse searchResponse;
            recipeManager =
            new RecipeManager(null, null);
            searchRequest = new SearchRequest();
            searchRequest.Name = new string('\0', 0);
            searchRequest.IsDone = true;
            searchRequest.IsFavorite = true;
            searchResponse = SearchRecipes(recipeManager, searchRequest);
            Assert.IsNotNull(searchResponse);
        }


    }
}
