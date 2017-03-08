using ItLabs.MyRecipes.Core.Automapper;
using ItLabs.MyRecipes.Core.Managers;
using ItLabs.MyRecipes.Core.Requests;
using ItLabs.MyRecipes.Core.Responses;
using ItLabs.MyRecipes.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace ItLabs.MyRecipes.UnitTests.RecipesManagerTests
{
    [TestClass]
    public class RecipesManagerTestData
    {
        Mock<IRecipeRepository> _mockRecipeRepository;
        Mock<IIngredientRepository> _mockIngredientRepository;
        RecipeManager _recipeManager;

        [TestInitialize]
        public void Initialize()
        {
            AutomapperBootstrap.Initialize();

            _mockRecipeRepository = new Mock<IRecipeRepository>();
            _mockIngredientRepository = new Mock<IIngredientRepository>();

            _recipeManager = new RecipeManager(_mockRecipeRepository.Object, _mockIngredientRepository.Object);
        }


        [TestMethod]
        public void SearchRecipes_ShouldReturnAllRecipes()
        {
            #region Arrange

            var searchRequest = new SearchRequest
            {
                Name = "",
                IsDone = false,
                IsFavorite = false,
                Page = 1,
                PageSize = 5
            };

            var excectedResponse = new SearchResponse()
            {
                Recipes = RecipeTestData.GetRecipes()
            };

            _mockRecipeRepository.Setup(x => x.GetRecipes())
                .Returns(RecipeTestData.GetDataRecipes());


            #endregion

            #region Act

            var actualResponse = _recipeManager.SearchRecipes(searchRequest);

            #endregion

            #region Assert
            Assert.IsTrue(actualResponse.IsSuccessful);
            Assert.AreEqual(excectedResponse.Recipes.Count(), actualResponse.Recipes.Count());
            
            int i = 0;
            foreach (var expectedRecipe in excectedResponse.Recipes)
            {
                Assert.AreEqual(expectedRecipe.Name, actualResponse.Recipes.ElementAt(i).Name);
                Assert.AreEqual(expectedRecipe.Description, actualResponse.Recipes.ElementAt(i).Description);
                Assert.AreEqual(expectedRecipe.IsDone, actualResponse.Recipes.ElementAt(i).IsDone);
                Assert.AreEqual(expectedRecipe.IsFavorite, actualResponse.Recipes.ElementAt(i).IsFavorite);
                i++;
            }
            #endregion
        }

        [TestMethod]
        public void SearchRecipes_ShouldReturnRecipe()
        {
            #region Arrange

            var searchRequest = new SearchRequest
            {
                Name = "Chocolate Gravy",
                IsDone = false,
                IsFavorite = false,
                Page = 1,
                PageSize = 5
            };

            var excectedResponse = new SearchResponse()
            {
                Recipes = RecipeTestData.GetRecipe()

            };

            _mockRecipeRepository.Setup(x => x.GetRecipes())
                .Returns(RecipeTestData.GetDataRecipes());


            #endregion

            #region Act

            var actualResponse = _recipeManager.SearchRecipes(searchRequest);

            #endregion

            #region Assert
            Assert.IsTrue(actualResponse.IsSuccessful);
            Assert.AreEqual(excectedResponse.Recipes.Count(), actualResponse.Recipes.Count());
            int i = 0;
            foreach (var expectedRecipe in excectedResponse.Recipes)
            {
                Assert.AreEqual(expectedRecipe.Name, actualResponse.Recipes.ElementAt(i).Name);
                Assert.AreEqual(expectedRecipe.Description, actualResponse.Recipes.ElementAt(i).Description);
                Assert.AreEqual(expectedRecipe.IsDone, actualResponse.Recipes.ElementAt(i).IsDone);
                Assert.AreEqual(expectedRecipe.IsFavorite, actualResponse.Recipes.ElementAt(i).IsFavorite);
                i++;
            }

            #endregion
        }


        [TestMethod]
        public void SearchRecipes_ShouldReturnDoneRecipe()
        {
            #region Arrange

            var searchRequest = new SearchRequest
            {
                Name = "Recipe",
                IsDone = true,
                IsFavorite = false,
                Page = 1,
                PageSize = 5
            };

            var excectedResponse = new SearchResponse()
            {
                Recipes = RecipeTestData.GetDoneRecipe()

            };

            _mockRecipeRepository.Setup(x => x.GetRecipes())
                .Returns(RecipeTestData.GetDataRecipes());


            #endregion

            #region Act

            var actualResponse = _recipeManager.SearchRecipes(searchRequest);

            #endregion

            #region Assert
            Assert.IsTrue(actualResponse.IsSuccessful);
            Assert.AreEqual(excectedResponse.Recipes.Count(), actualResponse.Recipes.Count());
            int i = 0;
            foreach (var expectedRecipe in excectedResponse.Recipes)
            {
                Assert.AreEqual(expectedRecipe.Name, actualResponse.Recipes.ElementAt(i).Name);
                Assert.AreEqual(expectedRecipe.Description, actualResponse.Recipes.ElementAt(i).Description);
                Assert.AreEqual(expectedRecipe.IsDone, actualResponse.Recipes.ElementAt(i).IsDone);
                Assert.AreEqual(expectedRecipe.IsFavorite, actualResponse.Recipes.ElementAt(i).IsFavorite);
                i++;
            }

            #endregion
        }
        [TestMethod]
        public void SearchRecipes_ShouldReturnError()
        {
            #region Arrange

            var searchRequest = new SearchRequest
            {
                Name = "Chocolate Gravy 2",
                IsDone = false,
                IsFavorite = false,
                Page = 1,
                PageSize = 5
            };

            var excectedResponse = new SearchResponse()
            {
               Errors = new System.Collections.Generic.List<string>
               {
                   "Recipe Name must contain characters and spaces only"
               }

            };

            #endregion

            #region Act

            var actualResponse = _recipeManager.SearchRecipes(searchRequest);

            #endregion

            #region Assert
            Assert.IsFalse(actualResponse.IsSuccessful);
            Assert.AreEqual(excectedResponse.Errors.Count(), actualResponse.Errors.Count());
            int i = 0;
            foreach (var expectedError in excectedResponse.Errors)
            {
                Assert.AreEqual(expectedError, actualResponse.Errors.ElementAt(i));
                i++;
            }

            #endregion
        }



    }


}



