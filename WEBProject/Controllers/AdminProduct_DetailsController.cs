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
    public class AdminProduct_DetailsController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminProduct_DetailsController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminProduct_Details
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Product_Details.Include(p => p.Product);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminProduct_Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Details = await _context.Product_Details
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.DetailID == id);
            if (product_Details == null)
            {
                return NotFound();
            }

            return View(product_Details);
        }

        // GET: AdminProduct_Details/Create
        public IActionResult Create()
        {
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name");
            return View();
        }

        // POST: AdminProduct_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailID,ProductDetails,ArticleNumber")] Product_Details product_Details)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_Details);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", product_Details.ArticleNumber);
            return View(product_Details);
        }

        // GET: AdminProduct_Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Details = await _context.Product_Details.FindAsync(id);
            if (product_Details == null)
            {
                return NotFound();
            }
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", product_Details.ArticleNumber);
            return View(product_Details);
        }

        // POST: AdminProduct_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailID,ProductDetails,ArticleNumber")] Product_Details product_Details)
        {
            if (id != product_Details.DetailID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_Details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_DetailsExists(product_Details.DetailID))
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
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", product_Details.ArticleNumber);
            return View(product_Details);
        }

        // GET: AdminProduct_Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Details = await _context.Product_Details
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.DetailID == id);
            if (product_Details == null)
            {
                return NotFound();
            }

            return View(product_Details);
        }

        // POST: AdminProduct_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_Details = await _context.Product_Details.FindAsync(id);
            _context.Product_Details.Remove(product_Details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_DetailsExists(int id)
        {
            return _context.Product_Details.Any(e => e.DetailID == id);
        }
    }
}
