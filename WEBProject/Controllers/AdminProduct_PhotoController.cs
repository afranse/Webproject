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
    public class AdminProduct_PhotoController : Controller
    {
        private readonly WebsiteContext C;

        public AdminProduct_PhotoController(WebsiteContext context)
        {
            C = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var websiteContext = C.Product_Photos.Include(p => p.Photo).Include(p => p.Product);
            return View(await websiteContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int PhotoID, int ArtNR)
        {
            return View(new Product_Photo() { PhotoID = PhotoID, ArticleNumber = ArtNR});
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? PhotoID, int? ArtNR)
        {
            if (PhotoID == null || ArtNR == null)
            {
                return NotFound();
            }
            int Photo = PhotoID ?? 0;
            int Art = ArtNR ?? 0;
            C.Product_Photos.Add(new Product_Photo() { PhotoID = Photo, ArticleNumber = Art });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? PhotoID, int? newPhotoID, int? ArtNR, int? newArtNR)
        {
            if (PhotoID == null || newPhotoID == null || ArtNR == null || newArtNR == null)
            {
                return NotFound();
            }
            int Photo = PhotoID ?? 0;
            int newPhoto = newPhotoID ?? 0;
            int Art = ArtNR ?? 0;
            int newArt = newArtNR ?? 0;

            Product_Photo Change = await C.Product_Photos.Where(x => x.ArticleNumber == Art).Where(y => y.PhotoID == Photo).FirstAsync();
            C.Product_Photos.Remove(Change);
            C.Product_Photos.Add(new Product_Photo() { ArticleNumber = newArt, PhotoID = newPhoto });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? PhotoID, int? ArtNR)
        {
            if (PhotoID == null || ArtNR == null)
            {
                return NotFound();
            }
            int Photo = PhotoID ?? 0;
            int Art = ArtNR ?? 0;
            Product_Photo P = C.Product_Photos.Where(x => x.ArticleNumber == Art).Where(y => y.PhotoID == Photo).First();
            C.Remove(P);
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
