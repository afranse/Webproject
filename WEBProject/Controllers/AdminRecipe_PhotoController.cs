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
    public class AdminRecipe_PhotoController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminRecipe_PhotoController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminRecipe_Photo
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Recipe_Photos.Include(r => r.Photo).Include(r => r.Recipe);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminRecipe_Photo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe_Photo = await _context.Recipe_Photos
                .Include(r => r.Photo)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.PhotoID == id);
            if (recipe_Photo == null)
            {
                return NotFound();
            }

            return View(recipe_Photo);
        }

        // GET: AdminRecipe_Photo/Create
        public IActionResult Create()
        {
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID");
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID");
            return View();
        }

        // POST: AdminRecipe_Photo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,PhotoID")] Recipe_Photo recipe_Photo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe_Photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID", recipe_Photo.PhotoID);
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", recipe_Photo.RecipeID);
            return View(recipe_Photo);
        }

        // GET: AdminRecipe_Photo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe_Photo = await _context.Recipe_Photos.FindAsync(id);
            if (recipe_Photo == null)
            {
                return NotFound();
            }
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID", recipe_Photo.PhotoID);
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", recipe_Photo.RecipeID);
            return View(recipe_Photo);
        }

        // POST: AdminRecipe_Photo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,PhotoID")] Recipe_Photo recipe_Photo)
        {
            if (id != recipe_Photo.PhotoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe_Photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Recipe_PhotoExists(recipe_Photo.PhotoID))
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
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID", recipe_Photo.PhotoID);
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", recipe_Photo.RecipeID);
            return View(recipe_Photo);
        }

        // GET: AdminRecipe_Photo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe_Photo = await _context.Recipe_Photos
                .Include(r => r.Photo)
                .Include(r => r.Recipe)
                .FirstOrDefaultAsync(m => m.PhotoID == id);
            if (recipe_Photo == null)
            {
                return NotFound();
            }

            return View(recipe_Photo);
        }

        // POST: AdminRecipe_Photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe_Photo = await _context.Recipe_Photos.FindAsync(id);
            _context.Recipe_Photos.Remove(recipe_Photo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Recipe_PhotoExists(int id)
        {
            return _context.Recipe_Photos.Any(e => e.PhotoID == id);
        }
    }
}
