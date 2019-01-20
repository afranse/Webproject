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
    public class AdminNormalCategory_ProductController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminNormalCategory_ProductController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminNormalCategory_Product
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.NormalCategory_Products.Include(n => n.Normal_Category).Include(n => n.Product);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminNormalCategory_Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var normalCategory_Product = await _context.NormalCategory_Products
                .Include(n => n.Normal_Category)
                .Include(n => n.Product)
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (normalCategory_Product == null)
            {
                return NotFound();
            }

            return View(normalCategory_Product);
        }

        // GET: AdminNormalCategory_Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Normal_Categories, "CategoryID", "Name");
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name");
            return View();
        }

        // POST: AdminNormalCategory_Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryID,ArticleNumber")] NormalCategory_Product normalCategory_Product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(normalCategory_Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Normal_Categories, "CategoryID", "Name", normalCategory_Product.CategoryID);
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", normalCategory_Product.ArticleNumber);
            return View(normalCategory_Product);
        }

        // GET: AdminNormalCategory_Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var normalCategory_Product = await _context.NormalCategory_Products.FindAsync(id);
            if (normalCategory_Product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Normal_Categories, "CategoryID", "Name", normalCategory_Product.CategoryID);
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", normalCategory_Product.ArticleNumber);
            return View(normalCategory_Product);
        }

        // POST: AdminNormalCategory_Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryID,ArticleNumber")] NormalCategory_Product normalCategory_Product)
        {
            if (id != normalCategory_Product.CategoryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(normalCategory_Product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NormalCategory_ProductExists(normalCategory_Product.CategoryID))
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
            ViewData["CategoryID"] = new SelectList(_context.Normal_Categories, "CategoryID", "Name", normalCategory_Product.CategoryID);
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", normalCategory_Product.ArticleNumber);
            return View(normalCategory_Product);
        }

        // GET: AdminNormalCategory_Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var normalCategory_Product = await _context.NormalCategory_Products
                .Include(n => n.Normal_Category)
                .Include(n => n.Product)
                .FirstOrDefaultAsync(m => m.CategoryID == id);
            if (normalCategory_Product == null)
            {
                return NotFound();
            }

            return View(normalCategory_Product);
        }

        // POST: AdminNormalCategory_Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var normalCategory_Product = await _context.NormalCategory_Products.FindAsync(id);
            _context.NormalCategory_Products.Remove(normalCategory_Product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NormalCategory_ProductExists(int id)
        {
            return _context.NormalCategory_Products.Any(e => e.CategoryID == id);
        }
    }
}
