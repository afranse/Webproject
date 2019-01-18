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
        private readonly WebsiteContext _context;

        public AdminText_NewsController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminText_News
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Text_News.Include(t => t.News).Include(t => t.Text);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminText_News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var text_News = await _context.Text_News
                .Include(t => t.News)
                .Include(t => t.Text)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (text_News == null)
            {
                return NotFound();
            }

            return View(text_News);
        }

        // GET: AdminText_News/Create
        public IActionResult Create()
        {
            ViewData["NewsID"] = new SelectList(_context.News_Items, "NewsID", "Title");
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content");
            return View();
        }

        // POST: AdminText_News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsID,TextID")] Text_News text_News)
        {
            if (ModelState.IsValid)
            {
                _context.Add(text_News);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewsID"] = new SelectList(_context.News_Items, "NewsID", "Title", text_News.NewsID);
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content", text_News.TextID);
            return View(text_News);
        }

        // GET: AdminText_News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var text_News = await _context.Text_News.FindAsync(id);
            if (text_News == null)
            {
                return NotFound();
            }
            ViewData["NewsID"] = new SelectList(_context.News_Items, "NewsID", "Title", text_News.NewsID);
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content", text_News.TextID);
            return View(text_News);
        }

        // POST: AdminText_News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsID,TextID")] Text_News text_News)
        {
            if (id != text_News.NewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(text_News);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Text_NewsExists(text_News.NewsID))
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
            ViewData["NewsID"] = new SelectList(_context.News_Items, "NewsID", "Title", text_News.NewsID);
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content", text_News.TextID);
            return View(text_News);
        }

        // GET: AdminText_News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var text_News = await _context.Text_News
                .Include(t => t.News)
                .Include(t => t.Text)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (text_News == null)
            {
                return NotFound();
            }

            return View(text_News);
        }

        // POST: AdminText_News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var text_News = await _context.Text_News.FindAsync(id);
            _context.Text_News.Remove(text_News);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Text_NewsExists(int id)
        {
            return _context.Text_News.Any(e => e.NewsID == id);
        }
    }
}
