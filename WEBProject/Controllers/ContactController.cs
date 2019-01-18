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
            
            return View();
        }


    }
}