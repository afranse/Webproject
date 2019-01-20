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
    public class AdminNews_ItemController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminNews_ItemController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminNews_Item
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.News_Items.Include(n => n.News_Category);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminNews_Item/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news_Item = await _context.News_Items
                .Include(n => n.News_Category)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (news_Item == null)
            {
                return NotFound();
            }

            return View(news_Item);
        }

        // GET: AdminNews_Item/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.News_Categories, "CategoryID", "CategoryID");
            return View();
        }

        // POST: AdminNews_Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsID,Event_Date,Last_Modified_Date,Title,CategoryID")] News_Item news_Item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news_Item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.News_Categories, "CategoryID", "CategoryID", news_Item.CategoryID);
            return View(news_Item);
        }

        // GET: AdminNews_Item/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news_Item = await _context.News_Items.FindAsync(id);
            if (news_Item == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.News_Categories, "CategoryID", "CategoryID", news_Item.CategoryID);
            return View(news_Item);
        }

        // POST: AdminNews_Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsID,Event_Date,Last_Modified_Date,Title,CategoryID")] News_Item news_Item)
        {
            if (id != news_Item.NewsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news_Item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!News_ItemExists(news_Item.NewsID))
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
            ViewData["CategoryID"] = new SelectList(_context.News_Categories, "CategoryID", "CategoryID", news_Item.CategoryID);
            return View(news_Item);
        }

        // GET: AdminNews_Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news_Item = await _context.News_Items
                .Include(n => n.News_Category)
                .FirstOrDefaultAsync(m => m.NewsID == id);
            if (news_Item == null)
            {
                return NotFound();
            }

            return View(news_Item);
        }

        // POST: AdminNews_Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news_Item = await _context.News_Items.FindAsync(id);
            _context.News_Items.Remove(news_Item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool News_ItemExists(int id)
        {
            return _context.News_Items.Any(e => e.NewsID == id);
        }
    }
}
