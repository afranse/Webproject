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
    public class AdminEmployee_ProfileController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminEmployee_ProfileController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminEmployee_Profile
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee_Profiles.ToListAsync());
        }

        // GET: AdminEmployee_Profile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Profile = await _context.Employee_Profiles
                .FirstOrDefaultAsync(m => m.Employee_ProfileID == id);
            if (employee_Profile == null)
            {
                return NotFound();
            }

            return View(employee_Profile);
        }

        // GET: AdminEmployee_Profile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminEmployee_Profile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Employee_ProfileID,Name,Job,Profile_PhotoPath,Region,CountryOrProvince")] Employee_Profile employee_Profile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee_Profile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee_Profile);
        }

        // GET: AdminEmployee_Profile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Profile = await _context.Employee_Profiles.FindAsync(id);
            if (employee_Profile == null)
            {
                return NotFound();
            }
            return View(employee_Profile);
        }

        // POST: AdminEmployee_Profile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Employee_ProfileID,Name,Job,Profile_PhotoPath,Region,CountryOrProvince")] Employee_Profile employee_Profile)
        {
            if (id != employee_Profile.Employee_ProfileID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee_Profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee_ProfileExists(employee_Profile.Employee_ProfileID))
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
            return View(employee_Profile);
        }

        // GET: AdminEmployee_Profile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Profile = await _context.Employee_Profiles
                .FirstOrDefaultAsync(m => m.Employee_ProfileID == id);
            if (employee_Profile == null)
            {
                return NotFound();
            }

            return View(employee_Profile);
        }

        // POST: AdminEmployee_Profile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee_Profile = await _context.Employee_Profiles.FindAsync(id);
            _context.Employee_Profiles.Remove(employee_Profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee_ProfileExists(int id)
        {
            return _context.Employee_Profiles.Any(e => e.Employee_ProfileID == id);
        }
    }
}
