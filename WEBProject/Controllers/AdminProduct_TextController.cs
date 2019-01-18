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
    public class AdminProduct_TextController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminProduct_TextController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminProduct_Text
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Product_Texts.Include(p => p.Product).Include(p => p.Text);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminProduct_Text/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Text = await _context.Product_Texts
                .Include(p => p.Product)
                .Include(p => p.Text)
                .FirstOrDefaultAsync(m => m.TextID == id);
            if (product_Text == null)
            {
                return NotFound();
            }

            return View(product_Text);
        }

        // GET: AdminProduct_Text/Create
        public IActionResult Create()
        {
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name");
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content");
            return View();
        }

        // POST: AdminProduct_Text/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleNumber,TextID")] Product_Text product_Text)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_Text);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", product_Text.ArticleNumber);
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content", product_Text.TextID);
            return View(product_Text);
        }

        // GET: AdminProduct_Text/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Text = await _context.Product_Texts.FindAsync(id);
            if (product_Text == null)
            {
                return NotFound();
            }
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", product_Text.ArticleNumber);
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content", product_Text.TextID);
            return View(product_Text);
        }

        // POST: AdminProduct_Text/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleNumber,TextID")] Product_Text product_Text)
        {
            if (id != product_Text.TextID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_Text);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_TextExists(product_Text.TextID))
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
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", product_Text.ArticleNumber);
            ViewData["TextID"] = new SelectList(_context.Text, "TextID", "Content", product_Text.TextID);
            return View(product_Text);
        }

        // GET: AdminProduct_Text/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Text = await _context.Product_Texts
                .Include(p => p.Product)
                .Include(p => p.Text)
                .FirstOrDefaultAsync(m => m.TextID == id);
            if (product_Text == null)
            {
                return NotFound();
            }

            return View(product_Text);
        }

        // POST: AdminProduct_Text/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_Text = await _context.Product_Texts.FindAsync(id);
            _context.Product_Texts.Remove(product_Text);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_TextExists(int id)
        {
            return _context.Product_Texts.Any(e => e.TextID == id);
        }
    }
}
