using ItLabs.MyRecipes.Core;
using System.Collections.Generic;
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
        public IEnumerable<string> Get()

        {
            return new string[] { "value1", "value2" };
        }

        // GET /recipes/4
        // [HttpGet, Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var recipe = _recipeManager.Get(id);
            if (recipe == null)
                return NotFound();
            return Ok(recipe);
        }
       //[HttpGet, Route("{name}")]
       // public IHttpActionResult Get(string name)
       // {
       //     //var recipe = _recipeManager.Get(name);
       //     //if (recipe == null)
       //     //    return NotFound();
       //     return Ok();
       // }

        [AcceptVerbs("PUT", "POST")]
        [HttpPost]
        public IHttpActionResult Post(Recipe recipe)
        {
            var isSave = _recipeManager.SaveRecipe(recipe);
            if (isSave.IsSuccessful)
                return Ok();
            return BadRequest();
        }
        //public HttpResponseMessage Post(Recipe recipe)
        //{
        //    recipe = _recipeManager.SaveRecipe(recipe);
        //    var response = Request.CreateResponse(HttpStatusCode.Created, recipe);

        //    string uri = Url.Link("DefaultApi", new { id = recipe.Id });
        //    response.Headers.Location = new Uri(uri);
        //    return response;
        //}
        // [HttpPut]
        //public IHttpActionResult Update(Recipe recipe)
        //{
        //    var isUpdated = _recipeManager.SaveRecipe(recipe.Id, recipe);
        //    if (isUpdated == true)
        //        return Ok();
        //    return BadRequest();
        //}

        //[HttpDelete]
        //public IHttpActionResult DeleteRecipe(int id)
        //{
        //    var isDeleted = _recipeManager.Remove(id);
        //    if (isDeleted == true)
        //        return Ok();
        //    return BadRequest();
        //}
        //    public Recipe Delete(int id)
        //    {
        //        Recipe recipe;

        //        if (!_recipeManager.Get(id))
        //            throw new HttpResponseException(HttpStatusCode.NotFound);
        //        _recipeManager.Remove(id);
        //        return recipe;

        //}

        //[HttpDelete, Route("{id}")]
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
