using ItLabs.MyRecipes.Core;
using ItLabs.MyRecipes.Core.Requests;
using System.Linq;
using System.Web.Http;

namespace ItLabs.MyRecipes.API.Controllers
{
    // [Route("recipes")]
    public class RecipesController : ApiController
    {
        public IRecipeManager _recipeManager { get; set; }
        public RecipesController(IRecipeManager recipeManager)
        {
            _recipeManager = recipeManager;
        }
        ///<summary>
        ///Search recipe
        ///</summary>
        ///<remarks>
        ///Search recipes by name, done, favourite and page
        ///</remarks>
        ///<returns></returns>
        ///<response code="200">successful operation</response>
        ///<response code="400">If the recipe is not found</response>
        ///<description>
        ///values that need to be considered for filter
        ///</description>
        [HttpGet, Route("Recipes")]
        [ActionName("Search")]
        public IHttpActionResult Search([FromUri]SearchRequest searchRequest)
        {
            var response = _recipeManager.SearchRecipes(searchRequest);
            if (!response.IsSuccessful || response.Errors.Count > 0)
            {
                var errorMessage = response.Errors.Aggregate((x, y) => $"{x} {y}");
                return BadRequest(errorMessage);
            }
              return Ok(response.Recipes);
        }
        ///<summary>
        ///Add new recipe 
        ///</summary>
        ///<remarks>
        ///Add new recipe
        ///</remarks>
        ///<returns></returns>
        /// <response code="201">Returns the newly created recipe</response>
        /// <response code="400">If the recipe is null</response>
        [HttpPost, Route("Recipes")]
        [ActionName("Post")]
        public IHttpActionResult Post(RecipeRequest recipe)
        {
            var response = _recipeManager.Create(recipe);
            if (!response.IsSuccessful || response.Recipe == null)
            {
                var errorMessage = response.Errors.Aggregate((x, y) => $"{x} {y}");
                return BadRequest(errorMessage);
            }
            return Ok(response.Recipe);
        }
        ///<summary>
        ///Update recipe 
        ///</summary>
        ///<remarks>
        ///Update an existing recipe
        ///</remarks>
        ///<returns></returns>
        ///<response code="200">Returns updated recipe</response>
        ///<response code="400">If the recipe is null</response>
        [HttpPut, Route("Recipes")]
        [ActionName("Post")]
        public IHttpActionResult Put(string name, [FromBody]RecipeRequest recipe)
        {
            var response = _recipeManager.Update(name,recipe);
            if (!response.IsSuccessful || response.Recipe == null)
            {
                var errorMessage = response.Errors.Aggregate((x, y) => $"{x} {y}");
                return BadRequest(errorMessage);
            }
            return Ok(response.Recipe);
       }
        ///<summary>
        ///Delete recipe 
        ///</summary>
        ///<remarks>
        ///Delete recipe
        ///</remarks>
        ///<returns></returns>
        ///<response code="200">Returns deleted recipe</response>
        ///<response code="400">If the recipe is null</response>
        [HttpDelete, Route("Recipes/{name}")]
        public IHttpActionResult Delete(string name)
        {
            var recipe = _recipeManager.GetRecipeByName(name);
            if (recipe == null)
                return BadRequest("This recipe was not found");
            _recipeManager.Remove(name);
            return Ok(name + " was successfully deleted");
        }
        ///<summary>
        ///Get ingredient
        ///</summary>
        ///<remarks>
        ///Get ingredient by name
        ///</remarks>
        ///<returns></returns>
        ///<response code="200">successful operation</response>
        ///<response code="400">Ingredient was not found</response>
        [HttpGet, Route("Ingredient")]
        [ActionName("GetIngredientNames")]
        public IHttpActionResult GetIngredientNames(string name)
        {
            var response = _recipeManager.SearchIngredients(name);
            if (response == null)
                return BadRequest("This ingredient was not found");
            return Ok(response);
        }
    }
}
