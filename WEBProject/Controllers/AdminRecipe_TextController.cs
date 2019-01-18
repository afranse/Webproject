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
    public class AdminRecipe_TextController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminRecipe_TextController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminRecipe_Text
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Recipe_Texts.Include(r => r.Recipe).Include(r => r.Text);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminRecipe_Text/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe_Text = await _context.Recipe_Texts
                .Include(r => r.Recipe)
                .Include(r => r.Text)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe_Text == null)
            {
                return NotFound();
            }

            return View(recipe_Text);
        }

        // GET: AdminRecipe_Text/Create
        public IActionResult Create()
        {
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID");
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content");
            return View();
        }

        // POST: AdminRecipe_Text/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,TextID")] Recipe_Text recipe_Text)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe_Text);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", recipe_Text.RecipeID);
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content", recipe_Text.TextID);
            return View(recipe_Text);
        }

        // GET: AdminRecipe_Text/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe_Text = await _context.Recipe_Texts.FindAsync(id);
            if (recipe_Text == null)
            {
                return NotFound();
            }
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", recipe_Text.RecipeID);
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content", recipe_Text.TextID);
            return View(recipe_Text);
        }

        // POST: AdminRecipe_Text/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,TextID")] Recipe_Text recipe_Text)
        {
            if (id != recipe_Text.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe_Text);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Recipe_TextExists(recipe_Text.RecipeID))
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
            ViewData["RecipeID"] = new SelectList(_context.Recipes, "RecipeID", "RecipeID", recipe_Text.RecipeID);
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content", recipe_Text.TextID);
            return View(recipe_Text);
        }

        // GET: AdminRecipe_Text/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe_Text = await _context.Recipe_Texts
                .Include(r => r.Recipe)
                .Include(r => r.Text)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe_Text == null)
            {
                return NotFound();
            }

            return View(recipe_Text);
        }

        // POST: AdminRecipe_Text/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe_Text = await _context.Recipe_Texts.FindAsync(id);
            _context.Recipe_Texts.Remove(recipe_Text);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Recipe_TextExists(int id)
        {
            return _context.Recipe_Texts.Any(e => e.RecipeID == id);
        }
    }
}
