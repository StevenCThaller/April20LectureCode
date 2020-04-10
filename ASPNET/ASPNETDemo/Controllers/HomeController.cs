using System;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        // ViewResult is the return type for any methods that ONLY render an html page
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("{word}")]
        public IActionResult Goodbye(object word)
        {
            if(!(word is int))
            {
                return RedirectToAction("Index");
            }

            if((int)word==10)
            {
                return RedirectToAction("Thanks");
            }
            else
            {
                return View();
            }
        }

        [HttpGet("thanks")]
        public ViewResult Thanks()
        {
            return View();
        }


    }
}