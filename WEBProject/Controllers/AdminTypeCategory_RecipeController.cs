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
    public class AdminTypeCategory_RecipeController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminTypeCategory_RecipeController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminTypeCategory_Recipe
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.TypeCategory_Recipes.Include(t => t.Recipe).Include(t => t.Type_Category);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminTypeCategory_Recipe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeCategory_Recipe = await _context.TypeCategory_Recipes
                .Include(t => t.Recipe)
                .Include(t => t.Type_Category)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (typeCategory_Recipe == null)
            {
                return NotFound();
            }

            return View(typeCategory_Recipe);
        }

        // GET: AdminTypeCategory_Recipe/Create
        public IActionResult Create()
        {
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID");
            ViewData["TypeID"] = new SelectList(_context.Type_Categories, "TypeID", "Name");
            return View();
        }

        // POST: AdminTypeCategory_Recipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeID,RecipeID,Weight,Percent")] TypeCategory_Recipe typeCategory_Recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeCategory_Recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", typeCategory_Recipe.RecipeID);
            ViewData["TypeID"] = new SelectList(_context.Type_Categories, "TypeID", "Name", typeCategory_Recipe.TypeID);
            return View(typeCategory_Recipe);
        }

        // GET: AdminTypeCategory_Recipe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeCategory_Recipe = await _context.TypeCategory_Recipes.FindAsync(id);
            if (typeCategory_Recipe == null)
            {
                return NotFound();
            }
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", typeCategory_Recipe.RecipeID);
            ViewData["TypeID"] = new SelectList(_context.Type_Categories, "TypeID", "Name", typeCategory_Recipe.TypeID);
            return View(typeCategory_Recipe);
        }

        // POST: AdminTypeCategory_Recipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeID,RecipeID,Weight,Percent")] TypeCategory_Recipe typeCategory_Recipe)
        {
            if (id != typeCategory_Recipe.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeCategory_Recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeCategory_RecipeExists(typeCategory_Recipe.RecipeID))
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
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", typeCategory_Recipe.RecipeID);
            ViewData["TypeID"] = new SelectList(_context.Type_Categories, "TypeID", "Name", typeCategory_Recipe.TypeID);
            return View(typeCategory_Recipe);
        }

        // GET: AdminTypeCategory_Recipe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeCategory_Recipe = await _context.TypeCategory_Recipes
                .Include(t => t.Recipe)
                .Include(t => t.Type_Category)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (typeCategory_Recipe == null)
            {
                return NotFound();
            }

            return View(typeCategory_Recipe);
        }

        // POST: AdminTypeCategory_Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeCategory_Recipe = await _context.TypeCategory_Recipes.FindAsync(id);
            _context.TypeCategory_Recipes.Remove(typeCategory_Recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeCategory_RecipeExists(int id)
        {
            return _context.TypeCategory_Recipes.Any(e => e.RecipeID == id);
        }
    }
}
