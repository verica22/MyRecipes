using ItLabs.MyRecipes.Core;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        // GET /recipes
        ///<summary>
        ///Get all recipes
        ///</summary>
        ///<remarks>
        ///Get a list of all recipes
        ///</remarks>
        ///<returns></returns>
        ///<response code="200"></response>
        [HttpGet]
        public IEnumerable<Recipe> GetRecipes()
        {
            return _recipeManager.GetAll();
        }

        // GET /recipes/4
        // [HttpGet, Route("{id}")]
        //public IHttpActionResult Get(int id)
        //{
        //    var recipe = _recipeManager.Get(id);
        //    if (recipe == null)
        //        return NotFound();
        //    return Ok(recipe);
        //}
        ///<summary>
        ///Get recipe 
        ///</summary>
        ///<remarks>
        ///Get recipe by name
        ///</remarks>
        ///<returns></returns>
        ///<response code="200"></response>
        [HttpGet, Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            var recipe = _recipeManager.GetRecipe(name);
            if (recipe == null)
                return NotFound();
            return Ok();
        }

        //[AcceptVerbs("PUT", "POST")]
        ///<summary>
        ///Add new recipe 
        ///</summary>
        ///<remarks>
        ///Add new recipe
        ///</remarks>
        ///<returns></returns>
        ///<response code="200"></response>
        [HttpPost]
        public IHttpActionResult Post(Recipe recipe)
        {
            var isSave = _recipeManager.SaveRecipe(recipe);
            if (isSave.IsSuccessful)
                return Ok();
            return BadRequest();
        }
        //[AcceptVerbs("PUT", "POST")]
        ///<summary>
        ///Update recipe 
        ///</summary>
        ///<remarks>
        ///Update an existing recipe
        ///</remarks>
        ///<returns></returns>
        ///<response code="200"></response>
        [HttpPut]
        public IHttpActionResult Put(Recipe recipe)
        {
            var isSave = _recipeManager.SaveRecipe(recipe);
            if (isSave.IsSuccessful)
                return Ok();
            return BadRequest();
        }
        ///<summary>
        ///Delete recipe 
        ///</summary>
        ///<remarks>
        ///Delete recipe
        ///</remarks>
        ///<returns></returns>
        ///<response code="200"></response>
        [HttpDelete]
        public void Delete(int id)
        {
            Recipe item = _recipeManager.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
             _recipeManager.Remove(id);

            
        }

        //public IHttpActionResult Search(string name, bool isDone, bool isFavourite, int? page)
        //{
        //    var recipes = _recipeManager.Search(name, isDone, isFavourite, page.HasValue ? page.Value : 1);
        //    if (recipes == null)
        //        return NotFound();
        //    return Ok(); 
        //}


    }
}
