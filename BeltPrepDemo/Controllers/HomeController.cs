using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using BeltPrepDemo.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BeltPrepDemo.Controllers
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

        [HttpPost("register")]
        public IActionResult Register(LogRegWrapper submission)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(u => u.Email == submission.RegUser.Email))
                {
                    ModelState.AddModelError("RegUser.Email", "A user exists with this email address");
                    return View("Index", submission);
                }
                PasswordHasher<User> pwhash = new PasswordHasher<User>();
                submission.RegUser.Password = pwhash.HashPassword(submission.RegUser, submission.RegUser.Password);
                dbContext.Add(submission.RegUser);
                dbContext.SaveChanges();

                HttpContext.Session.SetInt32("UserId", submission.RegUser.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }

        }

        [HttpPost("login")]
        public IActionResult Login(LogRegWrapper submission)
        {
            if(ModelState.IsValid)
            {
                User userInDb = dbContext.Users.FirstOrDefault(u => u.Email == submission.LogUser.LoginEmail);
                if(userInDb == null)
                {
                    ModelState.AddModelError("LogUser.LoginEmail", "Invalid Email/Password");
                    return View("Index", submission);
                }

                PasswordHasher<LoginUser> pwhash = new PasswordHasher<LoginUser>();
                var result = pwhash.VerifyHashedPassword(submission.LogUser, userInDb.Password, submission.LogUser.LoginPassword);

                if(result == 0) 
                {
                    ModelState.AddModelError("LogUser.LoginEmail", "Invalid Email/Password");
                    return View("Index", submission);
                }

                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index");
            }

            DashboardWrapper vMod = new DashboardWrapper();

            vMod.LoggedUser = dbContext.Users.FirstOrDefault(u => u.UserId == (int)UserId);
            vMod.AllTrucks = dbContext.Trucks
                .Include(t => t.User)
                .Include(t => t.Reviews)
                .Include(t => t.TruckStyles)
                .ThenInclude(ts => ts.Style)
                .ToList();
            return View(vMod);
        }

        [HttpGet("newtruck")]
        public IActionResult NewTruck()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index");
            }
            NewTruckWrapper vMod = new NewTruckWrapper();
            vMod.TruckForm = new FoodTruck();

            List<Style> styles = dbContext.Styles.ToList();
            vMod.TruckForm.Styles = new List<SelectListItem>();
            foreach(Style style in styles)
            {
                vMod.TruckForm.Styles.Add(new SelectListItem(style.StyleId, style.Name));
            }
            return View("NewTruck", vMod);
        }

        [HttpPost("createtruck")]
        public IActionResult CreateTruck(NewTruckWrapper submission)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index");
            }


            if(ModelState.IsValid)
            {
                if(dbContext.Trucks.Any(t => t.Name == submission.TruckForm.Name))
                {
                    ModelState.AddModelError("TruckForm.Name", "A truck with this name already exists.");
                    return NewTruck();
                }
                submission.TruckForm.UserId = (int)UserId;
                dbContext.Add(submission.TruckForm);
               
                foreach(SelectListItem item in submission.TruckForm.Styles)
                {
                    if(item.Selected)
                    {
                        TruckStyle toAdd = new TruckStyle();
                        toAdd.FoodTruckId = submission.TruckForm.FoodTruckId;
                        toAdd.StyleId = item.ItemId;
                        dbContext.Add(toAdd);
                    }
                }
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return NewTruck();
            }
        }

        [HttpGet("newstyle")]
        public IActionResult NewStyle()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost("createstyle")]
        public IActionResult CreateStyle(Style submission)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index");
            }

            if(ModelState.IsValid)
            {
                if(dbContext.Styles.Any(s => s.Name == submission.Name))
                {
                    ModelState.AddModelError("Name", "A style with that name already exists.");
                    return View("NewStyle");
                }
                dbContext.Add(submission);
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("NewStyle");
            }
        }

        [HttpGet("review/{TruckId}")]
        public IActionResult NewReview(int TruckId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index");
            }
            NewReviewWrapper vMod = new NewReviewWrapper();
            vMod.Truck = dbContext.Trucks
                .Include(t => t.User)
                .Include(t => t.Reviews)
                .ThenInclude(r => r.User)
                .Include(t => t.TruckStyles)
                .ThenInclude(ts => ts.Style)
                .FirstOrDefault(t => t.FoodTruckId == TruckId);

            return View("NewReview", vMod);
        }

        [HttpPost("createreview/{TruckId}")]
        public IActionResult CreateReview(int TruckId, NewReviewWrapper submission)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index");
            }
            if(ModelState.IsValid)
            {
                if(dbContext.Reviews.Any(r => r.UserId == (int)UserId && r.FoodTruckId == TruckId))
                {
                    ModelState.AddModelError("ReviewForm.Rating", "You have already left a review for this truck.");
                    return NewReview(TruckId);
                }

                submission.ReviewForm.UserId = (int)UserId;
                submission.ReviewForm.FoodTruckId = TruckId;
                
                dbContext.Add(submission.ReviewForm);
                dbContext.SaveChanges();
                return RedirectToAction("NewReview", new { TruckId = TruckId });
                
            }
            else
            {
                return NewReview(TruckId);
            }
        }

        [HttpGet("edittruck/{TruckId}")]
        public IActionResult EditTruck(int TruckId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index");
            }

            NewTruckWrapper ToEdit = new NewTruckWrapper();
            ToEdit.TruckForm = dbContext.Trucks
                .Include(t => t.TruckStyles)
                .ThenInclude(ts => ts.Style)
                .FirstOrDefault(t => t.FoodTruckId == TruckId);
            List<Style> styles = dbContext.Styles.ToList();
            ToEdit.StyleList = new List<SelectListItem>();
            foreach(Style style in styles)
            {
                SelectListItem toAdd = new SelectListItem(style.StyleId, style.Name);
                if(ToEdit.TruckForm.TruckStyles.Any(ts => ts.StyleId == style.StyleId))
                {
                    toAdd.Selected = true;
                }
                ToEdit.TruckForm.Styles.Add(toAdd);
            }
            return View("EditTruck", ToEdit);
        }

        [HttpPost("updatetruck/{TruckId}")]
        public IActionResult UpdateTruck(int TruckId, NewTruckWrapper submission)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("Index");
            }

            if(ModelState.IsValid)
            {
                if(dbContext.Trucks.Any(t => t.Name == submission.TruckForm.Name && t.FoodTruckId != TruckId))
                {
                    
                    ModelState.AddModelError("TruckForm.Name", "A truck with this name exists.");
                    return EditTruck(TruckId);
                }
                submission.TruckForm.FoodTruckId = TruckId;
                submission.TruckForm.UserId = (int)UserId;
                dbContext.Update(submission.TruckForm);
                dbContext.Entry(submission.TruckForm).Property("CreatedAt").IsModified = false;


               
                foreach(SelectListItem item in submission.TruckForm.Styles)
                {
                    if(item.Selected && !dbContext.TruckStyles.Any(ts => ts.FoodTruckId == TruckId && ts.StyleId == item.ItemId))
                    {
                        TruckStyle toAdd = new TruckStyle();
                        toAdd.FoodTruckId = submission.TruckForm.FoodTruckId;
                        toAdd.StyleId = item.ItemId;
                        dbContext.Add(toAdd);
                    }
                    else if(!item.Selected && dbContext.TruckStyles.Any(ts => ts.FoodTruckId == TruckId && ts.StyleId == item.ItemId))
                    {
                        TruckStyle ToRemove = dbContext.TruckStyles.FirstOrDefault(ts => ts.FoodTruckId == TruckId && ts.StyleId == item.ItemId);
                        dbContext.Remove(ToRemove);
                    }
                }
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return EditTruck(TruckId);
            }
        }
    
    }
    
}