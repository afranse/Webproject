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
    public class AdminProduct_TextController : Controller
    {
        private readonly WebsiteContext C;

        public AdminProduct_TextController(WebsiteContext context)
        {
            C = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var websiteContext = C.Product_Texts.Include(p => p.Product).Include(p => p.Text);
            return View(await websiteContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int ArtNR, int TextID)
        {
            return View(new Product_Text() { ArticleNumber = ArtNR, TextID = TextID });
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? TextID, int? ArtNR)
        {
            if (TextID == null || ArtNR == null)
            {
                return NotFound();
            }
            int Text = TextID ?? 0;
            int Art = ArtNR ?? 0;
            C.Product_Texts.Add(new Product_Text() { TextID = Text, ArticleNumber = Art });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? TextID, int? newTextID, int? ArtNR, int? newArtNR)
        {
            if (TextID == null || newTextID == null || ArtNR == null || newArtNR == null)
            {
                return NotFound();
            }
            int Text = TextID ?? 0;
            int newText = newTextID ?? 0;
            int Art = ArtNR ?? 0;
            int newArt = newArtNR ?? 0;

            Product_Text Change = await C.Product_Texts.Where(x => x.ArticleNumber == Art).Where(y => y.TextID == Text).FirstAsync();
            C.Product_Texts.Remove(Change);
            C.Product_Texts.Add(new Product_Text() { ArticleNumber = newArt, TextID = newText });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? TextID, int? ArtNR)
        {
            if (TextID == null || ArtNR == null)
            {
                return NotFound();
            }
            int Text = TextID ?? 0;
            int Art = ArtNR ?? 0;
            Product_Text P = C.Product_Texts.Where(x => x.ArticleNumber == Art).Where(y => y.TextID == Text).First();
            C.Remove(P);
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
