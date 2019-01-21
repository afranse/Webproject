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
    public class AdminRecipe_PhotoController : Controller
    {
        private readonly WebsiteContext C;

        public AdminRecipe_PhotoController(WebsiteContext context)
        {
            C = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var websiteContext = C.Recipe_Photos.Include(r => r.Photo).Include(r => r.Recipe);
            return View(await websiteContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int PhotoID, int RecipeID)
        {
            return View(new Recipe_Photo { PhotoID = PhotoID, RecipeID = RecipeID });
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? PhotoID, int? RecipeID)
        {
            if (PhotoID == null || RecipeID == null)
            {
                return NotFound();
            }
            int Photo = PhotoID ?? 0;
            int Art = RecipeID ?? 0;
            C.Recipe_Photos.Add(new Recipe_Photo() { PhotoID = Photo, RecipeID = Art });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? PhotoID, int? newPhotoID, int? RecipeID, int? newRecipeID)
        {
            if (PhotoID == null || newPhotoID == null || RecipeID == null || newRecipeID == null)
            {
                return NotFound();
            }
            int Photo = PhotoID ?? 0;
            int newPhoto = newPhotoID ?? 0;
            int Art = RecipeID ?? 0;
            int newArt = newRecipeID ?? 0;

            Recipe_Photo Change = await C.Recipe_Photos.Where(x => x.RecipeID == Art).Where(y => y.PhotoID == Photo).FirstAsync();
            C.Recipe_Photos.Remove(Change);
            C.Recipe_Photos.Add(new Recipe_Photo() { RecipeID = newArt, PhotoID = newPhoto });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? PhotoID, int? RecipeID)
        {
            if (PhotoID == null || RecipeID == null)
            {
                return NotFound();
            }
            int Photo = PhotoID ?? 0;
            int Art = RecipeID ?? 0;
            Recipe_Photo P = C.Recipe_Photos.Where(x => x.RecipeID == Art).Where(y => y.PhotoID == Photo).First();
            C.Remove(P);
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }

}
