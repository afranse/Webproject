using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBProject.Data;

namespace WEBProject.Controllers
{
    public class RecipesController : Controller
    {
        private readonly WebsiteContext _context;

        public RecipesController(WebsiteContext context)
        {
            _context = context;
            new Seeder(_context);
        }

        public IActionResult Index(int BranchID, string[] typestring)
        {
            BranchID++;
            List<Models.Type_Category> selectedType = getTypes(typestring);
            ViewBag.SelectedTypes = selectedType;
            if (selectedType.Count() == 0)
            {
                selectedType = _context.Type_Categories.Where(s => s.BranchCategory.BranchID.Equals(BranchID)).ToList();
            }
            ViewBag.Branch = BranchID;
            var recipes = (from r in _context.Recipes
                           join tcr in _context.TypeCategory_Recipes on r.RecipeID equals tcr.RecipeID
                           join tc in _context.Type_Categories on tcr.TypeID equals tc.TypeID
                           join bc in _context.Branch_Categories on tc.BranchID equals bc.BranchID
                           where (bc.BranchID == BranchID)
                           select r);
            if (recipes != null)
            {
                ViewBag.recipes = recipes.ToList();
            }
            else
            {
                ViewBag.recipes = new List<Models.Recipe>();
            }
            ViewBag.AllBranches = _context.Branch_Categories.ToList();
            ViewBag.AllTypes = _context.Type_Categories.Where(s => s.BranchCategory.BranchID.Equals(BranchID)).ToList();
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }
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
        public IActionResult Filter(int id)
        {
            return RedirectToAction("Index", new { BranchID = id - 1 });
        }

        public IActionResult Category(string[] types, int Branch)
        {
            return RedirectToAction("Index", new { typestring = types, BranchID = Branch - 1 });
        }
    }
}