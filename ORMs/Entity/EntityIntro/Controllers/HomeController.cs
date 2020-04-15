using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EntityIntro.Models;

namespace EntityIntro.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext; 

        public HomeController(MyContext context) 
        {
            dbContext = context;
        }


        [HttpGet("")]
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet("allritos")]
        public ViewResult ShowAll()
        {
            List<Burrito> AllRitos = dbContext.Burritos.ToList();
            return View(AllRitos);
        }

        [HttpPost("newrito")]
        public IActionResult NewBurrito(Burrito fromForm)
        {
            if(ModelState.IsValid)
            {
                // Local changes
                dbContext.Add(fromForm);
                
                // commit the changes to the database
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("editrito/{ritoId}")]
        public ViewResult EditRito(int ritoId)
        {
            Burrito ToEdit = dbContext.Burritos.FirstOrDefault(b => b.BurritoId == ritoId);

            return View(ToEdit);
        }

        [HttpPost("updaterito/{ritoId}")]
        public IActionResult UpdateBurrito(int ritoId, Burrito fromForm)
        {
            System.Console.WriteLine($"What's the burrito Id? {ritoId}");

            if(ModelState.IsValid)
            {
                // Burrito ToUpdate = dbContext.Burritos.FirstOrDefault(b => b.BurritoId == ritoId);
                // ToUpdate.Name = fromForm.Name;
                // ToUpdate.Tortilla = fromForm.Tortilla;
                // ToUpdate.Meat = fromForm.Meat;
                // ToUpdate.Rice = fromForm.Rice;
                // ToUpdate.Beans = fromForm.Beans;
                // ToUpdate.Vegetable = fromForm.Vegetable;
                // ToUpdate.Guac = fromForm.Guac;
                // ToUpdate.UpdatedAt = DateTime.Now;

                // dbContext.SaveChanges();

                fromForm.BurritoId = ritoId;
                dbContext.Update(fromForm);
                dbContext.Entry(fromForm).Property("CreatedAt").IsModified = false;
                dbContext.SaveChanges();


                
                return RedirectToAction("ShowAll");
            }
            else
            {
                return View("EditRito", fromForm);
            }


        }



        [HttpGet("deleterito/{ritoId}")]
        public RedirectToActionResult DeleteBurrito(int ritoId)
        {
            Burrito ToDelete = dbContext.Burritos.FirstOrDefault(b => b.BurritoId == ritoId);

            dbContext.Burritos.Remove(ToDelete);
            dbContext.SaveChanges();

            return RedirectToAction("ShowAll");
        }
    }
}