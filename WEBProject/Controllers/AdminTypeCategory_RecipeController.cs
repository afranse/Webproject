using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBProject.Data;
using WEBProject.Models;

namespace WEBProject.Controllers
{
    public class AdminTypeCategory_RecipeController : Controller
    {
        private readonly WebsiteContext C;

        public AdminTypeCategory_RecipeController(WebsiteContext context)
        {
            C = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var websiteContext = C.TypeCategory_Recipes.Include(t => t.Recipe).Include(t => t.Type_Category);
            return View(await websiteContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int TypeID, int RecipeID)
        {
            return View(new TypeCategory_Recipe { TypeID = TypeID, RecipeID = RecipeID });
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? TypeID, int? RecipeID)
        {
            if (TypeID == null || RecipeID == null)
            {
                return NotFound();
            }
            int Type = TypeID ?? 0;
            int Recipe = RecipeID ?? 0;
            C.TypeCategory_Recipes.Add(new TypeCategory_Recipe() { TypeID = Type, RecipeID = Recipe });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? TypeID, int? newTypeID, int? RecipeID, int? newRecipeID)
        {
            if (TypeID == null || newTypeID == null || RecipeID == null || newRecipeID == null)
            {
                return NotFound();
            }
            int Type = TypeID ?? 0;
            int newType = newTypeID ?? 0;
            int Recipe = RecipeID ?? 0;
            int newRecipe = newRecipeID ?? 0;

            TypeCategory_Recipe Change = await C.TypeCategory_Recipes.Where(x => x.RecipeID == Recipe).Where(y => y.TypeID == Type).FirstAsync();
            C.TypeCategory_Recipes.Remove(Change);
            C.TypeCategory_Recipes.Add(new TypeCategory_Recipe() { RecipeID = newRecipe, TypeID = newType });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? TypeID, int? RecipeID)
        {
            if (TypeID == null || RecipeID == null)
            {
                return NotFound();
            }
            int Type = TypeID ?? 0;
            int Recipe = RecipeID ?? 0;
            TypeCategory_Recipe P = C.TypeCategory_Recipes.Where(x => x.RecipeID == Recipe).Where(y => y.TypeID == Type).First();
            C.Remove(P);
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }    
}
