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
        private readonly WebsiteContext _context;

        public AdminPhoto_NewsController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminPhoto_News
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Photo_News.Include(p => p.News).Include(p => p.Photo);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminPhoto_News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo_News = await _context.Photo_News
                .Include(p => p.News)
                .Include(p => p.Photo)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (photo_News == null)
            {
                return NotFound();
            }

            return View(photo_News);
        }

        // GET: AdminPhoto_News/Create
        public IActionResult Create()
        {
            ViewData["NewsID"] = new SelectList(_context.News_Items, "NewsID", "Title");
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID");
            return View();
        }

        // POST: AdminPhoto_News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsID,PhotoID")] Photo_News photo_News)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photo_News);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewsID"] = new SelectList(_context.News_Items, "NewsID", "Title", photo_News.NewsID);
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID", photo_News.PhotoID);
            return View(photo_News);
        }

        // GET: AdminPhoto_News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo_News = await _context.Photo_News.FindAsync(id);
            if (photo_News == null)
            {
                return NotFound();
            }
            ViewData["NewsID"] = new SelectList(_context.News_Items, "NewsID", "Title", photo_News.NewsID);
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID", photo_News.PhotoID);
            return View(photo_News);
        }

        // POST: AdminPhoto_News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsID,PhotoID")] Photo_News photo_News)
        {
            if (id != photo_News.NewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photo_News);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Photo_NewsExists(photo_News.NewsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewsID"] = new SelectList(_context.News_Items, "NewsID", "Title", photo_News.NewsID);
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID", photo_News.PhotoID);
            return View(photo_News);
        }

        // GET: AdminPhoto_News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo_News = await _context.Photo_News
                .Include(p => p.News)
                .Include(p => p.Photo)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (photo_News == null)
            {
                return NotFound();
            }

            return View(photo_News);
        }

        // POST: AdminPhoto_News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photo_News = await _context.Photo_News.FindAsync(id);
            _context.Photo_News.Remove(photo_News);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Photo_NewsExists(int id)
        {
            return _context.Photo_News.Any(e => e.NewsID == id);
        }
    }
}
