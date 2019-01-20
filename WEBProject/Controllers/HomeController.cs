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

            List<Recipe> recipes = _context.Recipes.ToList().GetRange(0, 5).ToList();
            ViewBag.Themes(recipes);

            List<Branch_Category> Branches = _context.Branch_Categories.ToList();
            ViewBag.Branches = Branches;



            return View(HomeView);
        }


    }
}



