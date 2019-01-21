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
    public class AdminPhoto_NewsController : Controller
    {
        private readonly WebsiteContext C;

        public AdminPhoto_NewsController(WebsiteContext context)
        {
            C = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var websiteContext = C.Photo_News.Include(p => p.News).Include(p => p.Photo);
            return View(await websiteContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int PhotoID, int NewsID)
        {
            return View(new Photo_News() { PhotoID = PhotoID, NewsID = NewsID });
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? PhotoID, int? NewsID)
        {
            if (PhotoID == null || NewsID == null)
            {
                return NotFound();
            }
            int Photo = PhotoID ?? 0;
            int News = NewsID ?? 0;
            C.Photo_News.Add(new Photo_News() { PhotoID = Photo, NewsID = News });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? PhotoID, int? newPhotoID, int? NewsID, int? newNewsID)
        {
            if (PhotoID == null || newPhotoID == null || NewsID == null || newNewsID == null)
            {
                return NotFound();
            }
            int Photo = PhotoID ?? 0;
            int newPhoto = newPhotoID ?? 0;
            int News = NewsID ?? 0;
            int newNews = newNewsID ?? 0;

            Photo_News Change = await C.Photo_News.Where(x => x.NewsID == News).Where(y => y.PhotoID == Photo).FirstAsync();
            C.Photo_News.Remove(Change);
            C.Photo_News.Add(new Photo_News() { NewsID = newNews, PhotoID = newPhoto });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? PhotoID, int? NewsID)
        {
            if (PhotoID == null || NewsID == null)
            {
                return NotFound();
            }
            int Photo = PhotoID ?? 0;
            int News = NewsID ?? 0;
            Photo_News P = C.Photo_News.Where(x => x.NewsID == News).Where(y => y.PhotoID == Photo).First();
            C.Remove(P);
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
