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
    public class AdminNormalCategory_ProductController : Controller
    {
        private readonly WebsiteContext C;

        public AdminNormalCategory_ProductController(WebsiteContext context)
        {
            C = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var websiteContext = C.NormalCategory_Products.Include(n => n.Normal_Category).Include(n => n.Product);
            return View(await websiteContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int CategoryID, int ArtNR)
        {
            return View(new NormalCategory_Product { CategoryID = CategoryID, ArticleNumber = ArtNR });
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? CategoryID, int? ArtNR)
        {
            if (CategoryID == null || ArtNR == null)
            {
                return NotFound();
            }
            int Category = CategoryID ?? 0;
            int Art = ArtNR ?? 0;
            C.NormalCategory_Products.Add(new NormalCategory_Product() { CategoryID = Category, ArticleNumber = Art });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? CategoryID, int? newCategoryID, int? ArtNR, int? newArtNR)
        {
            if (CategoryID == null || newCategoryID == null || ArtNR == null || newArtNR == null)
            {
                return NotFound();
            }
            int Category = CategoryID ?? 0;
            int newCategory = newCategoryID ?? 0;
            int Art = ArtNR ?? 0;
            int newArt = newArtNR ?? 0;

            NormalCategory_Product Change = await C.NormalCategory_Products.Where(x => x.ArticleNumber == Art).Where(y => y.CategoryID == Category).FirstAsync();
            C.NormalCategory_Products.Remove(Change);
            C.NormalCategory_Products.Add(new NormalCategory_Product() { ArticleNumber = newArt, CategoryID = newCategory });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? CategoryID, int? ArtNR)
        {
            if (CategoryID == null || ArtNR == null)
            {
                return NotFound();
            }
            int Category = CategoryID ?? 0;
            int Art = ArtNR ?? 0;
            NormalCategory_Product P = C.NormalCategory_Products.Where(x => x.ArticleNumber == Art).Where(y => y.CategoryID == Category).First();
            C.Remove(P);
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
