using ItLabs.MyRecipes.Core;
using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ItLabs.MyRecipes.API.Controllers
{
    public class RecipeController : ApiController
    {
        public IRecipeManager _recipeManager { get; set; }

        public RecipeController(IRecipeManager recipeManager)
        {
            _recipeManager = recipeManager;

        }
        // GET /Recipe/GetRecipe/4
        // [HttpGet, Route("{id}")]
        [HttpGet]
        [ActionName("GetRecipe")]
        [Route("Recipe/GetRecipe/{id}")]
        public IHttpActionResult GetRecipe(int id)
        {
            var recipe = _recipeManager.Get(id);
            if (recipe == null)
                return NotFound();
            return Ok(recipe);
        }

        // [AcceptVerbs("PUT", "POST")]
        // [HttpPost]
        //public IHttpActionResult SaveRecipe(Recipe recipe)
        //{
        //    var isSave = _recipeManager.SaveRecipe(recipe);
        //    if (isSave == true)
        //        return Ok();
        //    return BadRequest();
        //}

        // [HttpPut]
        //public IHttpActionResult UpdateRecipe(Recipe recipe)
        //{
        //    var isUpdated = _recipeManager.SaveRecipe(recipe.Id, recipe);
        //    if (isUpdated == true)
        //        return Ok();
        //    return BadRequest();
        //}

        // [HttpDelete]
        //public IHttpActionResult DeleteRecipe(int id)
        //{
        //    var isDeleted = _recipeManager.Remove(id);
        //    if (isDeleted == true)
        //        return Ok();
        //    return BadRequest();
        //}

    }

    
}
