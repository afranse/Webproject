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
            ViewData["HeaderBackgroundImg"] = _context.Photos.ToList()[58].PhotoPath;
            Models.Employee_Profile Contact = _context.Employee_Profiles.FirstOrDefault();
            if (_context.Employee_Profiles != null)
            {
               // ViewBag.Contacten = new List<Models.Employee_Profile> { Contact, Contact, Contact, Contact, Contact, Contact, Contact, Contact, Contact };

                ViewBag.Contacten = _context.Employee_Profiles.ToList();
            }
            else
            {
                ViewBag.Contacten = new List<Models.Employee_Profile>();
            }
            PageContent ContactView = new PageContent(_context);

            PageContent T15contact = new PageContent(
            new int[] //photo
             {
                14,15,16,17
             },
            new int[] //text
             {
                16,17,18,19,20,21,22,23,24,25,26
             },
            _context);
            ContactView.addPage(T15contact);

            PageContent HowToContacts = new PageContent(
                new int[]
                {
                    2,3,4,5,6,7,8
                },
                new int[]
                {
                    2,3,4,5,6,7,8,10
                },
                _context);
            ContactView.addPage(HowToContacts);


            List<Branch_Category> Branches = _context.Branch_Categories.ToList();
            ViewBag.Branches = Branches;



            return View(ContactView);
        }

        public IActionResult specificContact(int id)
        {
            Models.Employee_Profile Contact = _context.Employee_Profiles.Where(e => e.Employee_ProfileID == id).FirstOrDefault();

            if (Contact == null)
            {
                return RedirectToAction(null, "no Employee found in Database");
            }
            
            return View(Contact);
        }


    }
}


