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
    public class AdminEmployee_Profile_EmailController : Controller
    {
        private readonly WebsiteContext _context;

        public AdminEmployee_Profile_EmailController(WebsiteContext context)
        {
            _context = context;
        }

        // GET: AdminEmployee_Profile_Email
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee_Profile_Emails.ToListAsync());
        }

        // GET: AdminEmployee_Profile_Email/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Profile_Email = await _context.Employee_Profile_Emails
                .FirstOrDefaultAsync(m => m.Email == id);
            if (employee_Profile_Email == null)
            {
                return NotFound();
            }

            return View(employee_Profile_Email);
        }

        // GET: AdminEmployee_Profile_Email/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminEmployee_Profile_Email/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,ProfileID")] Employee_Profile_Email employee_Profile_Email)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee_Profile_Email);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee_Profile_Email);
        }

        // GET: AdminEmployee_Profile_Email/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Profile_Email = await _context.Employee_Profile_Emails.FindAsync(id);
            if (employee_Profile_Email == null)
            {
                return NotFound();
            }
            return View(employee_Profile_Email);
        }

        // POST: AdminEmployee_Profile_Email/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,ProfileID")] Employee_Profile_Email employee_Profile_Email)
        {
            if (id != employee_Profile_Email.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee_Profile_Email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee_Profile_EmailExists(employee_Profile_Email.Email))
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
            return View(employee_Profile_Email);
        }

        // GET: AdminEmployee_Profile_Email/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee_Profile_Email = await _context.Employee_Profile_Emails
                .FirstOrDefaultAsync(m => m.Email == id);
            if (employee_Profile_Email == null)
            {
                return NotFound();
            }

            return View(employee_Profile_Email);
        }

        // POST: AdminEmployee_Profile_Email/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employee_Profile_Email = await _context.Employee_Profile_Emails.FindAsync(id);
            _context.Employee_Profile_Emails.Remove(employee_Profile_Email);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee_Profile_EmailExists(string id)
        {
            return _context.Employee_Profile_Emails.Any(e => e.Email == id);
        }
    }
}
