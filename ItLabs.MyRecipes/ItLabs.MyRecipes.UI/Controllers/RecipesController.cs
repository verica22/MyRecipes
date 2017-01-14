using ItLabs.MyRecipes.Core;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Collections.Generic;
using ItLabs.MyRecipes.Core.Responses;

namespace ItLabs.MyRecipes.UI.Controllers
{

    public class RecipesController : Controller
    {
        public IRecipeManager _recipeManager { get; set; }

        public RecipesController(IRecipeManager recipeManager)
        {
            _recipeManager = recipeManager;

        }

        public ActionResult Index(int? page)
        {
            var recipes = _recipeManager.Search(string.Empty, false, false, page.HasValue ? page.Value : 1);
            return View(recipes);
        }
        [HttpPost]
        public ActionResult Search(string name, bool isDone, bool isFavourite, int? page)
        {
            var recipes = _recipeManager.Search(name, isDone, isFavourite, page.HasValue ? page.Value : 1);
            return View(recipes);
        }

        ////GET: Detail
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = _recipeManager.Get(Convert.ToInt32(id));
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        //GET: Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        //POST: Remove
        [HttpPost]
        public ActionResult Remove(int Id)
        {

            _recipeManager.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult Save(Recipe recipe)
        {
            bool status = false;
            ResponseBase result = null;

            if (ModelState.IsValid)
            {
                result = _recipeManager.SaveRecipe(recipe);
                status = true;
            }

            return new JsonResult { Data = new { status, result, Url = "Index" } };

        }
        //GET: Edit
        public ActionResult Edit(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Recipe recipe = _recipeManager.Get(id);
            if (recipe == null)
                return HttpNotFound();
            return View(recipe);
        }


        public JsonResult GetIngredient(string term)
        {
             List<string> ingredients;

            // ingredients = _recipeManager.GetIngredient(term);

            ingredients = _recipeManager.GetIngredients().Where(x => x.Name.ToLower().StartsWith(term))
            .Select(e => e.Name).Distinct().ToList();

            //ingredients = _recipeManager.SearchIngredients(term);
            return Json(ingredients, JsonRequestBehavior.AllowGet);
        }
    }
}