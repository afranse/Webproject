﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEBProject.Data;
using WEBProject.Models;

namespace WEBProject.Controllers
{
    public class RecipesController : Controller
    {
        private readonly WebsiteContext _context;

        public RecipesController(WebsiteContext context)
        {
            _context = context;
            //new Seeder(_context);
        }

        public IActionResult Index(int BranchID, string[] typestring)
        {
            ViewData["HeaderBackgroundImg"] = _context.Photos.ToList()[58].PhotoPath;
            PageContent RecipeView = new PageContent(_context);
            PageContent RecipeText = new PageContent(
                new int[] //Photo
                {
                    2
                },

                new int[]
                {
                    2, 3
                },

                _context);

            RecipeView.addPage(RecipeText);

            ViewBag.Contact = _context.Employee_Profiles.FirstOrDefault();
            BranchID++;
            List<Models.Type_Category> selectedType = getTypes(typestring); //
            ViewBag.SelectedTypes = selectedType;
            if (selectedType.Count() == 0)
            {
                selectedType = _context.Type_Categories.Where(s => s.BranchCategory.BranchID.Equals(BranchID)).ToList();
            }
            ViewBag.Branch = BranchID;
            ViewBag.recipes = GetRecipes(BranchID);
            ViewBag.AllBranches = _context.Branch_Categories.ToList();
            ViewBag.AllTypes = _context.Type_Categories.Where(s => s.BranchCategory.BranchID.Equals(BranchID)).ToList();
            return View(RecipeView);
        }

        //Method to determine a specific type of recipe. 
        public IActionResult SpecificRecipe(int ID)
        {
            ViewData["HeaderBackgroundImg"] = _context.Photos.ToList()[58].PhotoPath;
            Recipe recipe = _context.Recipes.Where(r => r.RecipeID == ID).FirstOrDefault();
            if (recipe == null)
            {
                return RedirectToAction("Error message", new { message = "Recipe is not found" });
            }
            return View(recipe);
        }

        //Get the right recipes from a list. 
        public List<Models.Recipe> GetRecipes(int BranchID)
        {
            var recipes = (from r in _context.Recipes
                           join tcr in _context.TypeCategory_Recipes on r.RecipeID equals tcr.RecipeID
                           join tc in _context.Type_Categories on tcr.TypeID equals tc.TypeID
                           join bc in _context.Branch_Categories on tc.BranchID equals bc.BranchID
                           where (bc.BranchID == BranchID)
                           select r);
            if (recipes != null)
            {
                return recipes.ToList();
            }
            else
            {
                return new List<Models.Recipe>();
            }
        }

        public IActionResult Products()
        {
            return View();
        }

        //Get types of the branches 
        public List<Models.Type_Category> getTypes(string[] typestring)
        {
            List<Models.Type_Category> selectedTypes = new List<Models.Type_Category>();
            foreach (string s in typestring)
            {
                int i = -1;
                if (s.Count() > 0)
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