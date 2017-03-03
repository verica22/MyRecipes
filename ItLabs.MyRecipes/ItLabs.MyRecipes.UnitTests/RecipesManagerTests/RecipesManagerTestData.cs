using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ComponentModel;

namespace ItLabs.MyRecipes.UnitTests.RecipesManagerTests
{
    [TestClass]
   public  class RecipesManagerTestData
    {
        Mock<IContainer> mockContainer = new Mock<IContainer>();
        //Mock<ICustomerView> mockView = new Mock<ICustomerView>();
        //ICustomerView view = mockView.Object;

        [TestMethod]
        public void SearchRecipes_ShouldReturnAllRecipes()
        {
            //Setup

            //Action

            //Asertion
        }
        [TestMethod]
        public void GetRecipe_ShouldReturnCorrectRecipes()
        {
            //var testRecipes= GetTestRecipes();
            //var controller = new RecipesController(testRecipes);

            //var result = controller.GetRecipeNames("Recipe4") as OkNegotiatedContentResult<Recipe>;

            //Assert.IsNotNull(result);
            //Assert.AreEqual(testRecipes[4].Name, result.Content.Name);
       }
        [TestMethod]
        public void GetRecipe_ShouldNotFindRecipe()
        {
            //var controller = new RecipesController(GetTestRecipes());

            //var result = controller.GetRecipeNames("Recipe5");
            //Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    

    }
  
   
}
