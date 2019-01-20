using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBProject.Data;
using WEBProject.Models;

namespace WEBProject.Controllers
{
    public class HowWeWorkController : Controller
    {
        private readonly WebsiteContext _context;

        public HowWeWorkController(WebsiteContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["HeaderBackgroundImg"] = _context.Photos.ToList()[59].PhotoPath;
            PageContent HowWeWorkView = new PageContent(_context);
            PageContent LearnMore = new PageContent(
            new int[0], //photo

            new int[] //text
             {
                10,11,12,13,14
             },
            _context);
            HowWeWorkView.addPage(LearnMore);

            Employee_Profile contact = _context.Employee_Profiles.FirstOrDefault();
            if (contact == null)
            {
                return RedirectToAction("Foutmelding", new { message = "contact is not found" });
            }
            ViewBag.contact = contact;
            ViewBag.articles = Articles();
            return View(HowWeWorkView);
        }

        public List<News_Item> Articles()
        {
            var result = _context.News_Items.Where(p => p.News_Category.Category == "How we work");
            List<Models.News_Item> articles = new List<Models.News_Item>();

            if (result != null)
            {
                articles = result.ToList();
            }

            return articles;
        }


        public IActionResult Foutmelding(string message)
        {
            ViewData["message"] = message;
            return View();
        }
    }
}