using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBProject.Data;
using WEBProject.Models;
namespace WEBProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly WebsiteContext _context;

        public AboutController(WebsiteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["HeaderBackgroundImg"] = _context.Photos.ToList()[58].PhotoPath;
            ViewBag.News = _context.News_Items.Where(c => c.CategoryID == 3).FirstOrDefault();
            return View();
        }
    }
}