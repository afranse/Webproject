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
    public class AdminBranch_CategoryController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminBranch_CategoryController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminBranch_Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.Branch_Categories.ToListAsync());
        }

        // GET: AdminBranch_Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch_Category = await _context.Branch_Categories
                .FirstOrDefaultAsync(m => m.BranchID == id);
            if (branch_Category == null)
            {
                return NotFound();
            }

            return View(branch_Category);
        }

        // GET: AdminBranch_Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminBranch_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchID,Name")] Branch_Category branch_Category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branch_Category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branch_Category);
        }

        // GET: AdminBranch_Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch_Category = await _context.Branch_Categories.FindAsync(id);
            if (branch_Category == null)
            {
                return NotFound();
            }
            return View(branch_Category);
        }

        // POST: AdminBranch_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchID,Name")] Branch_Category branch_Category)
        {
            if (id != branch_Category.BranchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branch_Category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Branch_CategoryExists(branch_Category.BranchID))
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
            return View(branch_Category);
        }

        // GET: AdminBranch_Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch_Category = await _context.Branch_Categories
                .FirstOrDefaultAsync(m => m.BranchID == id);
            if (branch_Category == null)
            {
                return NotFound();
            }

            return View(branch_Category);
        }

        // POST: AdminBranch_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branch_Category = await _context.Branch_Categories.FindAsync(id);
            _context.Branch_Categories.Remove(branch_Category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Branch_CategoryExists(int id)
        {
            return _context.Branch_Categories.Any(e => e.BranchID == id);
        }
    }
}
