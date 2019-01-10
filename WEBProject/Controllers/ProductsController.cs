using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBProject.Data;

namespace WEBProject.Controllers
{

    public class ProductsController : Controller
    {
        private readonly WebsiteContext _context;

        public ProductsController(WebsiteContext context)
        {
            _context = context;
            new Seeder(_context);
        }

        public IActionResult Index(int BranchID)
        {
            BranchID++;
            ViewBag.Branch = BranchID;
            ViewBag.Types = _context.Type_Categories.Where(s => s.BranchCategory.BranchID.Equals(BranchID)).ToList();
            ViewBag.AllBranches = _context.Branch_Categories.ToList();

            return View();
        }

        public IActionResult Filter(int id)
        {
            return RedirectToAction("Index", new { BranchID = id-1});
        }

     
     
       
    }
}