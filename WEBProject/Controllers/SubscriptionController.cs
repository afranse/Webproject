using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBProject.Data;
using WEBProject.Models;

namespace WEBProject.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly WebsiteContext _context;

        public SubscriptionController(WebsiteContext context)
        {
            _context = context;
        }

        public IActionResult Index(string message)
        {
            ViewData["HeaderBackgroundImg"] = _context.Photos.ToList()[59].PhotoPath;
            ViewBag.SubscriptionMessage = message;
            return View();
        }

        public IActionResult subscribe(string adress)
        {
            string SubscriptionMessage = "";

            if (canAdd(adress))
            {
                SubscriptionMessage = "You have now been subscribed to our news letter!";
                _context.Subscribers.Add(new Subscriber() { Email = adress });
                _context.SaveChanges();
            }
            else
            {
                SubscriptionMessage = "You are already subscribed to our news letter.";

            }
            return RedirectToAction("Index", new { message = SubscriptionMessage });
        }

        public bool canAdd(string adress)
        {
            if (adress != null)
            {
                if (adress.Contains('@') && adress.Contains('.'))
                {
                    if (_context.Subscribers != null)
                    {
                        if (_context.Subscribers.Where(s => s.Email == adress).FirstOrDefault() == null)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public IActionResult Unsubscribe(string adress)
        {
            string SubscriptionMessage = "";

            if (canRemove(adress))
            {
                SubscriptionMessage = "You have now been unsubscribed from our news letter.";
                _context.Subscribers.Remove(_context.Subscribers.Where(s => s.Email == adress).FirstOrDefault());
                _context.SaveChanges();
            }
            else
            {
                SubscriptionMessage = "You were not subscribed in the first place.";
            }
            return RedirectToAction("Index", new { message = SubscriptionMessage }); 
        }

        public bool canRemove(string adress)
        {
            if(adress != null)
            {
                if (adress.Contains('@') && adress.Contains('.'))
                {
                    if (_context.Subscribers != null)
                    {
                        if (_context.Subscribers.Where(s => s.Email == adress).FirstOrDefault() != null)
                        {
                            return true; 
                        }
                    }
                }
            }
            return false;
        }
    }
}