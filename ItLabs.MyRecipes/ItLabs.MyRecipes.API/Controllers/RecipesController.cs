using ItLabs.MyRecipes.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

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
        //// GET /recipes
        /////<summary>
        /////Get all recipes
        /////</summary>
        /////<remarks>
        /////Get a list of all recipes
        /////</remarks>
        /////<returns></returns>
        /////<response code="200"></response>
        ////[HttpGet, Route("{recipes}")]
        //[HttpGet]
        //[ActionName("GetRecipes")]
        //[ResponseType(typeof(IEnumerable<Recipe>))]
        //public IHttpActionResult GetRecipes()
        //{
        //    var recipes = _recipeManager.GetAll();
        //    if (recipes == null)
        //        return BadRequest();
        //    return Ok(recipes);
        //}
        /////<summary>
        /////Get recipe 
        /////</summary>
        /////<remarks>
        /////Get recipe by name
        /////</remarks>
        /////<returns></returns>
        /////<response code="200"></response>
        //[HttpGet, Route("Recipes/{name}")]
        //// [Res]
        //[ActionName("Get")]
        //public IHttpActionResult Get(string name)
        //{
           
        //    var recipe = _recipeManager.GetRecipe(name);
        //    if (recipe == null)
        //        return BadRequest();
        //    return Ok(recipe);
        //}
        ///<summary>
        ///Search recipe
        ///</summary>
        ///<remarks>
        ///Search recipes by name, done, favourite and page
        ///</remarks>
        ///<returns></returns>
        ///<response code="200">successful operation</response>
        ///<description>
        ///values that need to be considered for filter
        ///</description>

        [HttpGet, Route("Recipes/Search")]
        [ActionName("Search")]
        public IHttpActionResult Search([FromUri]string name, [FromUri]bool isDone, [FromUri]bool isFavourite, [FromUri] int? page)
        {
            var recipes = _recipeManager.Search(name, isDone, isFavourite, page.HasValue ? page.Value : 1);
            if (recipes.Count == 0)
                return NotFound();
            return Ok(recipes);
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
        [HttpPost]
        public IHttpActionResult Post(Recipe recipe)
        {
            var isSave = _recipeManager.Add(recipe);
            var SaveError = "";
            if (isSave.IsSuccessful)
              return Ok(recipe);
            else if (isSave.Errors.Count > 0)
            {
                foreach (var message in isSave.Errors)
                {
                    SaveError += message;
                }
            }
            return BadRequest("Recipe was not successfully saved" + ", " + SaveError);
         // return BadRequest("Recipe was not successfully saved" + isSave.Errors[0]);
   }

        ///<summary>
        ///Update recipe 
        ///</summary>
        ///<remarks>
        ///Update an existing recipe
        ///</remarks>
        ///<returns></returns>
        ///<response code="200"></response>
        [HttpPut]
       // [Route("{name}")]
        public IHttpActionResult Put(string name, [FromBody]Recipe recipe)
        {
            var isUpdated = _recipeManager.Update(recipe);
            var SaveError = "";
            if (isUpdated.IsSuccessful)
                return Ok(recipe);
            else if (isUpdated.Errors.Count > 0)
            {
                foreach (var message in isUpdated.Errors)
                {
                    SaveError += message;
                }
            }
            return BadRequest("Recipe was not successfully saved" + ", " + SaveError);
        }

        ///<summary>
        ///Delete recipe 
        ///</summary>
        ///<remarks>
        ///Delete recipe
        ///</remarks>
        ///<returns></returns>
        ///<response code="200"></response>
        [HttpDelete, Route("Recipes/{id}")]
        public IHttpActionResult Delete(int id)
        {
            Recipe item = _recipeManager.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _recipeManager.Remove(id);

            return Ok(item);

        }


        ///<summary>
        ///Get ingredient
        ///</summary>
        ///<remarks>
        ///Get ingredient by name
        ///</remarks>
        ///<returns></returns>
        ///<response code="200"></response>
        [HttpGet, Route("Ingredient/{name}")]
        [ActionName("GetIngredient")]
        public IHttpActionResult GetIngredient(string name)
        {
            var ingredient = _recipeManager.GetIngredient(name);
            if (ingredient == null)
                return BadRequest();
            return Ok(ingredient);
        }



    }
}
