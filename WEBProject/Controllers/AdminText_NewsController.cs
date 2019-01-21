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
    public class AdminText_NewsController : Controller
    {
        private readonly WebsiteContext C;

        public AdminText_NewsController(WebsiteContext context)
        {
            C = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var websiteContext = C.Text_News.Include(t => t.News).Include(t => t.Text);
            return View(await websiteContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int TextID, int NewsID)
        {
            return View(new Text_News { TextID = TextID, NewsID = NewsID });
        }

        [HttpPost]
        public async Task<IActionResult> Create(int? TextID, int? NewsID)
        {
            if (TextID == null || NewsID == null)
            {
                return NotFound();
            }
            int Text = TextID ?? 0;
            int News = NewsID ?? 0;
            C.Text_News.Add(new Text_News() { TextID = Text, NewsID = News });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? TextID, int? newTextID, int? NewsID, int? newNewsID)
        {
            if (TextID == null || newTextID == null || NewsID == null || newNewsID == null)
            {
                return NotFound();
            }
            int Text = TextID ?? 0;
            int newText = newTextID ?? 0;
            int News = NewsID ?? 0;
            int newNews = newNewsID ?? 0;

            Text_News Change = await C.Text_News.Where(x => x.NewsID == News).Where(y => y.TextID == Text).FirstAsync();
            C.Text_News.Remove(Change);
            C.Text_News.Add(new Text_News() { NewsID = newNews, TextID = newText });
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? NewsID, int? TextID)
        {
            if (NewsID == null || TextID == null)
            {
                return NotFound();
            }
            int News = NewsID ?? 0;
            int Text = TextID ?? 0;
            Text_News P = C.Text_News.Where(x => x.TextID == Text).Where(y => y.NewsID == News).First();
            C.Remove(P);
            await C.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
