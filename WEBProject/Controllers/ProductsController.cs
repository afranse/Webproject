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
           // new Seeder(_context);
        }

        public IActionResult Index(int BranchID, string[] typestring, string[] catstring)
        {
            BranchID++;
            List<Models.Type_Category> selectedTypes = getTypes(typestring);

            List<Models.Normal_Category> selectedCategories = GetCategories(catstring);

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
            fillBags(BranchID, selectedTypes, selectedCategories);
            
            return View();
        }

        //convert the string array to Type_Category List
        private List<Models.Type_Category> getTypes(string[] typestring)
        {
            List<Models.Type_Category> selectedTypes = new List<Models.Type_Category>();
            foreach (string s in typestring)
            {
                int i = 0;
                int.TryParse(s.Substring(2), out i);
                selectedTypes.Add(_context.Type_Categories.Where(x => x.TypeID.Equals(i)).FirstOrDefault());
            }
            return selectedTypes;
        }

        //convert the string array to Normal_Category List
        private List<Models.Normal_Category> GetCategories(string[] catstring)
        {
            List<Models.Normal_Category> selectedCategories = new List<Models.Normal_Category>();
            foreach (string s in catstring)
            {
                int i = 0;
                int.TryParse(s.Substring(2), out i);
                selectedCategories.Add(_context.Normal_Categories.Where(x => x.CategoryID.Equals(i)).FirstOrDefault());
            }
            return selectedCategories;
        }
        
        //fill the needed ViewBags 
        private void fillBags(int BranchID, List<Models.Type_Category> selectedTypes, List<Models.Normal_Category> selectedCategories)
        {
            //current Branch
            ViewBag.Branch = BranchID;
            //The query to search products
            ViewBag.Products = GetProducts(BranchID, selectedTypes, selectedCategories);
            //all Branches
            ViewBag.AllBranches = _context.Branch_Categories.ToList();
            //all Types from certain Branch
            ViewBag.AllTypes = _context.Type_Categories.Where(s => s.BranchCategory.BranchID.Equals(BranchID)).ToList();
            //all Categories from certain Types
            ViewBag.AllCat = (from C in _context.Normal_Categories
                              join TC in selectedTypes on C.TypeID equals TC.TypeID
                              select C).ToList(); ;
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

        public IActionResult SpecificProduct (int ID)
        {
            Models.Product P = _context.Products.Where(p => p.ArticleNumber == ID).FirstOrDefault();
            return View(P);
        }





        public List<Models.Product> GetProducts(int BranchID, List<Models.Type_Category> selectedTypes, List<Models.Normal_Category> selectedCategories)
        {
            var producten = (from p in _context.Products
                             join ncp in _context.NormalCategory_Products on p.ArticleNumber equals ncp.ArticleNumber
                             join nc in _context.Normal_Categories on ncp.CategoryID equals nc.CategoryID
                             join tc in _context.Type_Categories on nc.TypeID equals tc.TypeID
                             join bc in _context.Branch_Categories on tc.BranchID equals bc.BranchID
                             join stc in selectedTypes on tc.TypeID equals stc.TypeID
                             join snc in selectedCategories on nc.CategoryID equals snc.CategoryID
                             where (bc.BranchID == BranchID)
                             select p);

            //To catch any exceptions
            if (producten != null)
            {
               return producten.ToList();
            }
            else
            {
                return new List<Models.Product>();
            }
        }




    }
}