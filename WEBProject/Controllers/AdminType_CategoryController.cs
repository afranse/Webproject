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
    public class AdminType_CategoryController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminType_CategoryController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminType_Category
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Type_Categories.Include(t => t.BranchCategory);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminType_Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_Category = await _context.Type_Categories
                .Include(t => t.BranchCategory)
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (type_Category == null)
            {
                return NotFound();
            }

            return View(type_Category);
        }

        // GET: AdminType_Category/Create
        public IActionResult Create()
        {
            ViewData["BranchID"] = new SelectList(_context.Branch_Categories, "BranchID", "Name");
            return View();
        }

        // POST: AdminType_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeID,Name,BranchID")] Type_Category type_Category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(type_Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchID"] = new SelectList(_context.Branch_Categories, "BranchID", "Name", type_Category.BranchID);
            return View(type_Category);
        }

        // GET: AdminType_Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_Category = await _context.Type_Categories.FindAsync(id);
            if (type_Category == null)
            {
                return NotFound();
            }
            ViewData["BranchID"] = new SelectList(_context.Branch_Categories, "BranchID", "Name", type_Category.BranchID);
            return View(type_Category);
        }

        // POST: AdminType_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeID,Name,BranchID")] Type_Category type_Category)
        {
            if (id != type_Category.TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(type_Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Type_CategoryExists(type_Category.TypeID))
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
            ViewData["BranchID"] = new SelectList(_context.Branch_Categories, "BranchID", "Name", type_Category.BranchID);
            return View(type_Category);
        }

        // GET: AdminType_Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var type_Category = await _context.Type_Categories
                .Include(t => t.BranchCategory)
                .FirstOrDefaultAsync(m => m.TypeID == id);
            if (type_Category == null)
            {
                return NotFound();
            }

            return View(type_Category);
        }

        // POST: AdminType_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var type_Category = await _context.Type_Categories.FindAsync(id);
            _context.Type_Categories.Remove(type_Category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Type_CategoryExists(int id)
        {
            return _context.Type_Categories.Any(e => e.TypeID == id);
        }
    }
}
