using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBProject.Data;

namespace WEBProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly WebsiteContext _context;

        public NewsController(WebsiteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["HeaderBackgroundImg"] = _context.Photos.ToList()[58].PhotoPath;
            return View();
        }
    }
}