using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBProject.Data;
using WEBProject.Models;

namespace WEBProject.Controllers
{

    public class ContactController : Controller
    {
        private readonly WebsiteContext _context;

        public ContactController(WebsiteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            PageContent ContactView = new PageContent(_context);

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
            ContactView.addPage(Anecdote);

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
            ContactView.addPage(Themes);

            PageContent Spotlight = new PageContent(
                new int[0],
                new int[]
                {
                    9
                },
                _context);
            ContactView.addPage(Spotlight);



            List<Branch_Category> Branches = _context.Branch_Categories.ToList();
            ViewBag.Branches = Branches;



            return View(ContactView);
        }


    }
}


