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
        [HttpGet, Route("{name}")]
        public IHttpActionResult Get(string name)
        {
            var recipe = _recipeManager.GetRecipe(name);
            if (recipe == null)
                return NotFound();
            return Ok();
        }

        //[AcceptVerbs("PUT", "POST")]
        [HttpPost]
        public IHttpActionResult Post(Recipe recipe)
        {
            var isSave = _recipeManager.SaveRecipe(recipe);
            if (isSave.IsSuccessful)
                return Ok();
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult Put(Recipe recipe)
        {
            var isSave = _recipeManager.SaveRecipe(recipe);
            if (isSave.IsSuccessful)
                return Ok();
            return BadRequest();
        }
      
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


    }
}
