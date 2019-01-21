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
    public class AdminRecipe_TextController : Controller
    {
        private readonly WebsiteContext C;

        public AdminRecipe_TextController(WebsiteContext context)
        {
            C = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var websiteContext = C.Recipe_Texts.Include(r => r.Recipe).Include(r => r.Text);
            return View(await websiteContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int TextID, int RecipeID)
        {
            return View(new Recipe_Text() { TextID = TextID, RecipeID = RecipeID });
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? TextID, int? RecipeID)
        {
            if (TextID == null || RecipeID == null)
            {
                return NotFound();
            }
            int Text = TextID ?? 0;
            int Recipe = RecipeID ?? 0;
            C.Recipe_Texts.Add(new Recipe_Text() { TextID = Text, RecipeID = Recipe });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? RecipeID, int? newRecipeID, int? TextID, int? newTextID)
        {
            if (RecipeID == null || newRecipeID == null || TextID == null || newTextID == null)
            {
                return NotFound();
            }
            int Recipe = RecipeID ?? 0;
            int newRecipe = newRecipeID ?? 0;
            int Text = TextID ?? 0;
            int newText = newTextID ?? 0;

            Recipe_Text Change = await C.Recipe_Texts.Where(x => x.TextID == Text).Where(y => y.RecipeID == Recipe).FirstAsync();
            C.Recipe_Texts.Remove(Change);
            C.Recipe_Texts.Add(new Recipe_Text() { TextID = newText, RecipeID = newRecipe });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? RecipeID, int? TextID)
        {
            if (RecipeID == null || TextID == null)
            {
                return NotFound();
            }
            int Recipe = RecipeID ?? 0;
            int Text = TextID ?? 0;
            Recipe_Text P = C.Recipe_Texts.Where(x => x.TextID == Text).Where(y => y.RecipeID == Recipe).First();
            C.Remove(P);
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
