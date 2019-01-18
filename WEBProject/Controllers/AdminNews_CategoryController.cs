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
    public class AdminNews_CategoryController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminNews_CategoryController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminNews_Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.News_Categories.ToListAsync());
        }

        // GET: AdminNews_Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news_Category = await _context.News_Categories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (news_Category == null)
            {
                return NotFound();
            }

            return View(news_Category);
        }

        // GET: AdminNews_Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminNews_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,Category")] News_Category news_Category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news_Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(news_Category);
        }

        // GET: AdminNews_Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news_Category = await _context.News_Categories.FindAsync(id);
            if (news_Category == null)
            {
                return NotFound();
            }
            return View(news_Category);
        }

        // POST: AdminNews_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,Category")] News_Category news_Category)
        {
            if (id != news_Category.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news_Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!News_CategoryExists(news_Category.CategoryID))
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
            return View(news_Category);
        }

        // GET: AdminNews_Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news_Category = await _context.News_Categories
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (news_Category == null)
            {
                return NotFound();
            }

            return View(news_Category);
        }

        // POST: AdminNews_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news_Category = await _context.News_Categories.FindAsync(id);
            _context.News_Categories.Remove(news_Category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool News_CategoryExists(int id)
        {
            return _context.News_Categories.Any(e => e.CategoryID == id);
        }
    }
}
