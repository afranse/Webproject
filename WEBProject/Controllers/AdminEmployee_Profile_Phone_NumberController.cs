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
    public class AdminEmployee_Profile_Phone_NumberController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminEmployee_Profile_Phone_NumberController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminEmployee_Profile_Phone_Number
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee_Profile_Phone_Numbers.ToListAsync());
        }

        // GET: AdminEmployee_Profile_Phone_Number/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Profile_Phone_Number = await _context.Employee_Profile_Phone_Numbers
                .FirstOrDefaultAsync(m => m.Number == id);
            if (employee_Profile_Phone_Number == null)
            {
                return NotFound();
            }

            return View(employee_Profile_Phone_Number);
        }

        // GET: AdminEmployee_Profile_Phone_Number/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminEmployee_Profile_Phone_Number/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,ProfileID")] Employee_Profile_Phone_Number employee_Profile_Phone_Number)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee_Profile_Phone_Number);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee_Profile_Phone_Number);
        }

        // GET: AdminEmployee_Profile_Phone_Number/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Profile_Phone_Number = await _context.Employee_Profile_Phone_Numbers.FindAsync(id);
            if (employee_Profile_Phone_Number == null)
            {
                return NotFound();
            }
            return View(employee_Profile_Phone_Number);
        }

        // POST: AdminEmployee_Profile_Phone_Number/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Number,ProfileID")] Employee_Profile_Phone_Number employee_Profile_Phone_Number)
        {
            if (id != employee_Profile_Phone_Number.Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee_Profile_Phone_Number);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee_Profile_Phone_NumberExists(employee_Profile_Phone_Number.Number))
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
            return View(employee_Profile_Phone_Number);
        }

        // GET: AdminEmployee_Profile_Phone_Number/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Profile_Phone_Number = await _context.Employee_Profile_Phone_Numbers
                .FirstOrDefaultAsync(m => m.Number == id);
            if (employee_Profile_Phone_Number == null)
            {
                return NotFound();
            }

            return View(employee_Profile_Phone_Number);
        }

        // POST: AdminEmployee_Profile_Phone_Number/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee_Profile_Phone_Number = await _context.Employee_Profile_Phone_Numbers.FindAsync(id);
            _context.Employee_Profile_Phone_Numbers.Remove(employee_Profile_Phone_Number);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee_Profile_Phone_NumberExists(string id)
        {
            return _context.Employee_Profile_Phone_Numbers.Any(e => e.Number == id);
        }
    }
}
