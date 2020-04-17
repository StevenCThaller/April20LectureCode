using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EntityIntro.Models;
// This is needed when using Include statements so bring it in if you
// ever have a One to Many or Many to Many relationship
using Microsoft.EntityFrameworkCore;

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
            ViewBag.RitoMasters = dbContext.RitoMasters;
            return View();
        }

        [HttpGet("allritos")]
        public ViewResult ShowAll()
        {
            List<Burrito> AllBurritos = dbContext.Burritos.Include(b => b.RitoMaster).ToList();
            return View(AllBurritos);
        }

        [HttpGet("allmasters")]
        public ViewResult ShowMasters()
        {
            List<RitoMaster> AllMasters = dbContext.RitoMasters.Include(m => m.Burritos).ToList();
            return View(AllMasters);
        }

        [HttpPost("newrito")]
        public IActionResult NewBurrito(Burrito fromForm)
        {
            if(ModelState.IsValid)
            {

                if(dbContext.Burritos.Any(b => b.Name == fromForm.Name))
                {
                    ViewBag.RitoMasters = dbContext.RitoMasters;
                    ModelState.AddModelError("Name", "You cannot create a burrito with the same name as an existing burrito.");
                    return View("Index");
                }

                // Local changes
                dbContext.Add(fromForm);
                
                // commit the changes to the database
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RitoMasters = dbContext.RitoMasters;
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
        // [HttpPut("updaterito/{ritoId}")]
        public IActionResult UpdateBurrito(int ritoId, Burrito fromForm)
        {
            System.Console.WriteLine($"What's the burrito Id? {ritoId}");

            if(ModelState.IsValid)
            {
                
                if(dbContext.Burritos.Any(b => b.Name == fromForm.Name && b.BurritoId != ritoId))
                {
                    ModelState.AddModelError("Name", "You cannot create a burrito with the same name as an existing burrito.");
                    return View("EditRito", fromForm);
                }
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

        [HttpGet("newritomaster")]
        public ViewResult NewRitoMaster()
        {
            return View();
        }

        [HttpPost("newritomaster")]
        public IActionResult AddMaster(RitoMaster fromForm)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.RitoMasters.Any(m => m.FirstName == fromForm.FirstName && m.LastName == fromForm.LastName))
                {
                    ModelState.AddModelError("FirstName", "That 'rito master already exists.");
                    return View("NewRitoMaster");
                }
                dbContext.Add(fromForm);
                dbContext.SaveChanges();
                return RedirectToAction("ShowMasters");
            }
            else
            {
                return View("NewRitoMaster");
            }
        }
    }
}