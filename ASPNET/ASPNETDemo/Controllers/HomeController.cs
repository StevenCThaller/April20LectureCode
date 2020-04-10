using System;
using System.Collections.Generic;
using ASPNETDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        // ViewResult is the return type for any methods that ONLY render an html page
        public ViewResult Index()
        {
            // Declare a list of strings that I want to send through
            // to my cshtml
            ViewBag.SideKicks = new List<string>{"Robin", "Batgirl", "Barnacle Boy", "Speedy", "Kid Flash", "Bucky Barnes"};
            // Passing the list of strings through to the cshmtml
            return View();
        }

        [HttpPost("newhero")]
        public IActionResult Goodbye(SuperHero fromForm)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Thanks", fromForm);
            }
            else 
            {
                ViewBag.SideKicks = new List<string>{"Robin", "Batgirl", "Barnacle Boy", "Speedy", "Kid Flash", "Bucky Barnes"};
                return View("Index", fromForm);
            }
        }

        [HttpGet("thanks")]
        public ViewResult Thanks(SuperHero fromRedirect)
        {
            return View(fromRedirect);
        }


    }
}