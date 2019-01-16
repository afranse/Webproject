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
            //new Seeder(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }
    }
}