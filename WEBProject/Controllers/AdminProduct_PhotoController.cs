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
    public class AdminProduct_PhotoController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminProduct_PhotoController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminProduct_Photo
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Product_Photos.Include(p => p.Photo).Include(p => p.Product);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminProduct_Photo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Photo = await _context.Product_Photos
                .Include(p => p.Photo)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ArticleNumber == id);
            if (product_Photo == null)
            {
                return NotFound();
            }

            return View(product_Photo);
        }

        // GET: AdminProduct_Photo/Create
        public IActionResult Create()
        {
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID");
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name");
            return View();
        }

        // POST: AdminProduct_Photo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArticleNumber,PhotoID")] Product_Photo product_Photo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product_Photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID", product_Photo.PhotoID);
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", product_Photo.ArticleNumber);
            return View(product_Photo);
        }

        // GET: AdminProduct_Photo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Photo = await _context.Product_Photos.FindAsync(id);
            if (product_Photo == null)
            {
                return NotFound();
            }
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID", product_Photo.PhotoID);
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", product_Photo.ArticleNumber);
            return View(product_Photo);
        }

        // POST: AdminProduct_Photo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArticleNumber,PhotoID")] Product_Photo product_Photo)
        {
            if (id != product_Photo.ArticleNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product_Photo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Product_PhotoExists(product_Photo.ArticleNumber))
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
            ViewData["PhotoID"] = new SelectList(_context.Photos, "PhotoID", "PhotoID", product_Photo.PhotoID);
            ViewData["ArticleNumber"] = new SelectList(_context.Products, "ArticleNumber", "Name", product_Photo.ArticleNumber);
            return View(product_Photo);
        }

        // GET: AdminProduct_Photo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product_Photo = await _context.Product_Photos
                .Include(p => p.Photo)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ArticleNumber == id);
            if (product_Photo == null)
            {
                return NotFound();
            }

            return View(product_Photo);
        }

        // POST: AdminProduct_Photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product_Photo = await _context.Product_Photos.FindAsync(id);
            _context.Product_Photos.Remove(product_Photo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product_PhotoExists(int id)
        {
            return _context.Product_Photos.Any(e => e.ArticleNumber == id);
        }
    }
}
