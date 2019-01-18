using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBProject.Data;
using WEBProject.Models;

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
        public List<Models.Type_Category> getTypes(string[] typestring)
        {
            List<Models.Type_Category> selectedTypes = new List<Models.Type_Category>();
            foreach (string s in typestring)
            {
                int i = -1;
                if (s.Count() > 2)
                {
                    int.TryParse(s.Substring(2), out i);
                    if (i != -1)
                    {
                        var result = _context.Type_Categories.Where(x => x.TypeID.Equals(i)).FirstOrDefault();
                        if (result != null)
                        {
                            selectedTypes.Add(result);
                        }
                    }
                }
            }
            return selectedTypes;
        }

        //convert the string array to Normal_Category List
        public List<Models.Normal_Category> GetCategories(string[] catstring)
        {
            List<Models.Normal_Category> selectedCategories = new List<Models.Normal_Category>();
            foreach (string s in catstring)
            {
                int i = -1;
                if (s.Count() > 2)
                {
                    int.TryParse(s.Substring(2), out i);
                    if (i != -1)
                    {
                        var result = _context.Normal_Categories.Where(x => x.CategoryID.Equals(i)).FirstOrDefault();
                        if (result != null)
                        {
                            selectedCategories.Add(result);
                        }
                    }
                }
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
            ViewBag.AllBranches = getBranches();
            //all Types from certain Branch
            ViewBag.AllTypes = getAllTypes(BranchID);
            //all Categories from certain Types
            ViewBag.AllCat = getAllCategorie(selectedTypes);
        }

        public List<Models.Branch_Category> getBranches()
        {
            if (_context.Branch_Categories != null)
            {
                return _context.Branch_Categories.ToList();
            }
            else
            {
                return new List<Models.Branch_Category>();
            }
        }

        public List<Models.Normal_Category> getAllCategorie(List<Models.Type_Category> selectedTypes)
        {
            var AllCats = (from C in _context.Normal_Categories
                           join TC in selectedTypes on C.TypeID equals TC.TypeID
                           select C);
            if (AllCats != null)
            {
                return AllCats.ToList();
            }
            else
            {
                return new List<Models.Normal_Category>();
            }
        }

        public List<Models.Type_Category> getAllTypes(int BranchID)
        {
            var AllTypes = _context.Type_Categories.Where(s => s.BranchCategory.BranchID.Equals(BranchID));
            if (AllTypes != null)
            {
                return AllTypes.ToList();
            }
            else
            {
                return new List<Models.Type_Category>();
            }
        }



        

        public IActionResult Category(string[] types, string[] Categories, int Branch)
        {

            return RedirectToAction("Index", new { typestring = types, catstring = Categories, BranchID = Branch - 1 });
        }


        public IActionResult SpecificProduct(int ID)
        {
            //specific product
            Product Product = _context.Products.Where(k => k.ArticleNumber == ID).FirstOrDefault();
            if (Product == null)
            {
                return RedirectToAction("Foutmelding", new { message = "Product is not found" });
            }
            
            Employee_Profile contact = _context.Employee_Profiles.FirstOrDefault();

            PageContent SpecificProductView = new PageContent(_context);
            PageContent LearnMore = new PageContent(
            new int[0], //photo

            new int[] //text
             {
                10,11,12,13,14
             },
            _context);
            SpecificProductView.addPage(LearnMore);

            RelatedProduct(Product);
            InspirationRecipe();

            ViewBag.ShowHeaderImg = false;
            ViewBag.Product = Product;
            ViewBag.contact = contact;
            return View(SpecificProductView);
        }

        private void RelatedProduct(Product product)
        {
            //all products with the same CategoryID
            var result = _context.Products.Where(p => p.NormalCategory[0].CategoryID == product.NormalCategory[0].CategoryID);
            List<Models.Product> relatedProducts = new List<Product>();

            if (result != null)
            {
                relatedProducts = result.ToList();
            }

            ViewBag.relatedProducts = relatedProducts;
        }


        private void InspirationRecipe()
        {
            List<Recipe> recipes = new List<Recipe>();
            List<Recipe> inspiratie = new List<Recipe>();

            if (_context.Recipes != null)
            {
                recipes = _context.Recipes.ToList();
                Random rnd = new Random();
                if (recipes.Count() > 1)
                {
                    int r1 = rnd.Next(recipes.Count());
                    int r2 = rnd.Next(recipes.Count());
                    while (r2 == r1)
                    {
                        r2 = rnd.Next(recipes.Count());
                    }
                    inspiratie.Add(recipes[r1]);
                    inspiratie.Add(recipes[r2]);
                }
                else
                {
                    inspiratie.Add(recipes[0]);
                }
            }
            ViewBag.inspiratie = inspiratie;
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

        //---------------------------------------------------------------------------------------------------------------------------------------------------------
        public IActionResult Filter(int id)
        {
            return RedirectToAction("Index", new { BranchID = id - 1 });
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
        //---------------------------------------------------------------------------------------------------------------------------------------------------------



    }
}