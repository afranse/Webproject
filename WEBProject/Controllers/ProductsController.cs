using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index(int BranchID, string[] typestring, string[] catstring)
        {
            BranchID++;
            List<Models.Type_Category> selectedTypes = new List<Models.Type_Category>();
            foreach (string s in typestring)
            {
                int i = 0;
                int.TryParse(s.Substring(2), out i);
                selectedTypes.Add(_context.Type_Categories.Where(x => x.TypeID.Equals(i)).FirstOrDefault());
            }

            List<Models.Normal_Category> selectedCategories = new List<Models.Normal_Category>();
            foreach (string s in catstring)
            {
                int i = 0;
                int.TryParse(s.Substring(2), out i);
                selectedCategories.Add(_context.Normal_Categories.Where(x => x.CategoryID.Equals(i)).FirstOrDefault());
            }

            ViewBag.SelectedTypes = selectedTypes;
            ViewBag.SelectedCategories = selectedCategories;

            if (selectedTypes.Count() == 0)
            {
                selectedTypes = _context.Type_Categories.Where(s => s.BranchCategory.BranchID.Equals(BranchID)).ToList();
            }
            if (selectedCategories.Count() == 0)
            {
                selectedCategories = (from C in _context.Normal_Categories
                        join TC in selectedTypes on C.TypeID equals TC.TypeID
                        select C).ToList();
            }









            ViewBag.Branch = BranchID;
            var producten = (from p in _context.Products
                             join ncp in _context.NormalCategory_Products on p.ArticleNumber equals ncp.ArticleNumber
                             join nc in _context.Normal_Categories on ncp.CategoryID equals nc.CategoryID
                             join tc in _context.Type_Categories on nc.TypeID equals tc.TypeID
                             join bc in _context.Branch_Categories on tc.BranchID equals bc.BranchID
                             join stc in selectedTypes on tc.TypeID equals stc.TypeID
                             join snc in selectedCategories on nc.CategoryID equals snc.CategoryID
                             where (bc.BranchID == BranchID)
                             select p);

            if(producten != null)
            {
                ViewBag.Products = producten.ToList();
            }
            else
            {
                ViewBag.Products = new List <Models.Product>();
            }


            ViewBag.AllBranches = _context.Branch_Categories.ToList();
            ViewBag.AllTypes = _context.Type_Categories.Where(s => s.BranchCategory.BranchID.Equals(BranchID)).ToList();
            ViewBag.AllCat = (from C in _context.Normal_Categories
                              join TC in selectedTypes on C.TypeID equals TC.TypeID
                              select C).ToList(); ;
            


            return View();
        }

        public IActionResult Filter(int id)
        {
            return RedirectToAction("Index", new { BranchID = id-1});
        }

        public IActionResult Migrate()
        {
            try
            {
                _context.Database.Migrate();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Foutmelding", new { message = e.Message });
            }
        }

        public IActionResult Foutmelding(string message)
        {
            ViewData["message"] = message;
            return View();
        }

        public IActionResult Category(string[] types, string[]Categories, int Branch)
        {
            
            return RedirectToAction("Index", new {typestring = types, catstring = Categories, BranchID = Branch-1});
        }





    }
}