using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WEBProject.Controllers
{
    public class AdminLoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.HideMenu = true;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            return RedirectToAction("Index","Admin");
        }
    }
}