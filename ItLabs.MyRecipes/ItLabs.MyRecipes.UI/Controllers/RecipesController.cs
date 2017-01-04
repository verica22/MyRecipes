using ItLabs.MyRecipes.Domain;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PagedList;
using System.Collections.Generic;

namespace ItLabs.MyRecipes.UI.Controllers
{

    public class RecipesController : Controller
    {

        public const int pageSize = 8;

        public IRecipeManager _recipeManager { get; set; }

        public RecipesController(IRecipeManager recipeManager)
        {
            _recipeManager = recipeManager;
        }

        public ActionResult Index(int? page)
        {

            int pageNumber = (page ?? 1);

            return View(_recipeManager.GetRecipes().ToPagedList(pageNumber, pageSize));
        }
        [HttpPost]
        public ActionResult Search(string name, bool isDone, bool isFavourite, int? page)
        {
            int pageNumber = (page ?? 1);
            var recipes = _recipeManager.SearchRecipes(name, isDone, isFavourite);
            
            return View(recipes);
        }

        ////GET: Detail
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = _recipeManager.FindById(Convert.ToInt32(id));
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

            if (ModelState.IsValid)
            {
                _recipeManager.Save(recipe);
                status = true;
                
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status, Url = "Index" } };
         
        }
        //GET: Edit
        public ActionResult Edit(int id)
        {
            if (id == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Recipe recipe = _recipeManager.FindById(id);
            if (recipe == null)
                return HttpNotFound();
            return View(recipe);
        }
        //POST: Edit
        [HttpPost]
        public ActionResult Edit(Recipe recipe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _recipeManager.Edit(recipe);
                    return RedirectToAction("Index");
                }
                return View(recipe);
            }
            catch
            {
                return View();
            }

        }

        public JsonResult GetIngredients(string term)
        {

            List<string> ingredients;
            ingredients = _recipeManager.GetIngredients().Where(x => x.Name.ToLower().StartsWith(term))
                .Select(e => e.Name).Distinct().ToList();

            return Json(ingredients, JsonRequestBehavior.AllowGet);
        }
    }
}