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
    public class AdminNormal_CategoryController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminNormal_CategoryController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminNormal_Category
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Normal_Categories.Include(n => n.TypeCategory);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminNormal_Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var normal_Category = await _context.Normal_Categories
                .Include(n => n.TypeCategory)
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (normal_Category == null)
            {
                return NotFound();
            }

            return View(normal_Category);
        }

        // GET: AdminNormal_Category/Create
        public IActionResult Create()
        {
            ViewData["TypeID"] = new SelectList(_context.Type_Categories, "TypeID", "Name");
            return View();
        }

        // POST: AdminNormal_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,Name,TypeID")] Normal_Category normal_Category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(normal_Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeID"] = new SelectList(_context.Type_Categories, "TypeID", "Name", normal_Category.TypeID);
            return View(normal_Category);
        }

        // GET: AdminNormal_Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var normal_Category = await _context.Normal_Categories.FindAsync(id);
            if (normal_Category == null)
            {
                return NotFound();
            }
            ViewData["TypeID"] = new SelectList(_context.Type_Categories, "TypeID", "Name", normal_Category.TypeID);
            return View(normal_Category);
        }

        // POST: AdminNormal_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,Name,TypeID")] Normal_Category normal_Category)
        {
            if (id != normal_Category.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(normal_Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Normal_CategoryExists(normal_Category.CategoryID))
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
            ViewData["TypeID"] = new SelectList(_context.Type_Categories, "TypeID", "Name", normal_Category.TypeID);
            return View(normal_Category);
        }

        // GET: AdminNormal_Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var normal_Category = await _context.Normal_Categories
                .Include(n => n.TypeCategory)
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (normal_Category == null)
            {
                return NotFound();
            }

            return View(normal_Category);
        }

        // POST: AdminNormal_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var normal_Category = await _context.Normal_Categories.FindAsync(id);
            _context.Normal_Categories.Remove(normal_Category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Normal_CategoryExists(int id)
        {
            return _context.Normal_Categories.Any(e => e.CategoryID == id);
        }
    }
}
