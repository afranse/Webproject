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
    public class AdminTextController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminTextController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminText
        public async Task<IActionResult> Index()
        {
            var websiteContext = _context.Text.Include(t => t.Language);
            return View(await websiteContext.ToListAsync());
        }

        // GET: AdminText/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var text = await _context.Text
                .Include(t => t.Language)
                .FirstOrDefaultAsync(m => m.TextID == id);
            if (text == null)
            {
                return NotFound();
            }

            return View(text);
        }

        // GET: AdminText/Create
        public IActionResult Create()
        {
            ViewData["LangID"] = new SelectList(_context.Languages, "LangID", "LangTag");
            return View();
        }

        // POST: AdminText/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TextID,Content,WebsitePageID,LangID")] Text text)
        {
            if (ModelState.IsValid)
            {
                _context.Add(text);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LangID"] = new SelectList(_context.Languages, "LangID", "LangTag", text.LangID);
            return View(text);
        }

        // GET: AdminText/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var text = await _context.Text.FindAsync(id);
            if (text == null)
            {
                return NotFound();
            }
            ViewData["LangID"] = new SelectList(_context.Languages, "LangID", "LangTag", text.LangID);
            return View(text);
        }

        // POST: AdminText/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TextID,Content,WebsitePageID,LangID")] Text text)
        {
            if (id != text.TextID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(text);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TextExists(text.TextID))
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
            ViewData["LangID"] = new SelectList(_context.Languages, "LangID", "LangTag", text.LangID);
            return View(text);
        }

        // GET: AdminText/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var text = await _context.Text
                .Include(t => t.Language)
                .FirstOrDefaultAsync(m => m.TextID == id);
            if (text == null)
            {
                return NotFound();
            }

            return View(text);
        }

        // POST: AdminText/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var text = await _context.Text.FindAsync(id);
            _context.Text.Remove(text);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TextExists(int id)
        {
            return _context.Text.Any(e => e.TextID == id);
        }
    }
}
