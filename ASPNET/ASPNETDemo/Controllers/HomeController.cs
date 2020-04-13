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
            IndexWrapper vMod = new IndexWrapper();
            vMod.SideKicks = new List<SideKick>(){new SideKick("Robin"), new SideKick("Bat girl"), new SideKick("Kid Flash"), new SideKick("Barnacle Boy")};
            return View(vMod);
        }

        [HttpPost("kickitup")]
        public IActionResult KickIt(IndexWrapper wrapper)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Gracias", wrapper.Kick);
            }
            else
            {
                wrapper.SideKicks = new List<SideKick>(){new SideKick("Robin"), new SideKick("Bat girl"), new SideKick("Kid Flash"), new SideKick("Barnacle Boy")};
                return View("Index", wrapper);
            }

        }

        [HttpPost("newhero")]
        public IActionResult Goodbye(IndexWrapper wrapper)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Thanks", wrapper.Hero);
            }
            else 
            {
                wrapper.SideKicks = new List<SideKick>(){new SideKick("Robin"), new SideKick("Bat girl"), new SideKick("Kid Flash"), new SideKick("Barnacle Boy")};
                return View("Index", wrapper);
            }
        }

        [HttpGet("thanks")]
        public ViewResult Thanks(SuperHero fromRedirect)
        {
            return View(fromRedirect);
        }

        [HttpGet("gracias")]
        public ViewResult Gracias(SideKick fromRedirect)
        {
            return View(fromRedirect);
        }


    }
}