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
            ViewBag.Contact = new Models.Employee_Profile
            {
                Name = "Justin Ulsamer",
                Job = "Developer",
                Profile_PhotoPath = "/images/Sir.jpg",
                Region = "Rijswijk",
                CountryOrProvince = "The Netherlands",
                Emails = new List<Models.Employee_Profile_Email>
                {
                    new Models.Employee_Profile_Email
                    {
                        Email = "17042623@student.hhs.nl"
                    }
                },
                Phone_Numbers = new List<Models.Employee_Profile_Phone_Number>
                {
                    new Models.Employee_Profile_Phone_Number
                    {
                        Number = "0000000000000000000"
                    }
                }
            };
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

            return View();
        }


    }
}


