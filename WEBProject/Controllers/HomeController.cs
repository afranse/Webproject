using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBProject.Models;
using WEBProject.Data;

namespace WEBProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebsiteContext _context;


        public HomeController(WebsiteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["HeaderBackgroundImg"] = _context.Photos.ToList()[58].PhotoPath;
            PageContent HomeView = new PageContent(_context);

            PageContent Anecdote = new PageContent(
            new int[] //photo
             {
                1
             },
            new int[] //text
             {
                1
             },
            _context);
            HomeView.addPage(Anecdote);

            PageContent Themes = new PageContent(
                new int[]
                {
                    2,3,4,5,6,7,8
                },
                new int[]
                {
                    2,3,4,5,6,7,8,10
                },
                _context);
            HomeView.addPage(Themes);

            PageContent Spotlight = new PageContent(
                new int[0],
                new int[]
                {
                    9
                },
                _context);
            HomeView.addPage(Spotlight);

            List<Recipe> recipes = _context.Recipes.Take(6).ToList(); //.GetRange(0, 6).ToList()
            ViewBag.Themes = recipes;

            List<string> recipesPaths = new List<string>();
            foreach(Recipe r in recipes)
            {
                recipesPaths.Add(_context.Recipe_Photos.Where(o => o.RecipeID == r.RecipeID).FirstOrDefault().Photo.PhotoPath);
            }
            ViewBag.ThemesPaths = recipesPaths;

            List<Branch_Category> Branches = _context.Branch_Categories.ToList();
            ViewBag.Branches = Branches;

            List<Product> products = _context.Products.Take(8).ToList();
            ViewBag.Spotlight = products;

            return View(HomeView);
        }


    }
}



