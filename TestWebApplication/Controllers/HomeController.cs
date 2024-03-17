using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWebApplication.Data;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicatonDbContext dataContext;
        public HomeController(ILogger<HomeController> logger, ApplicatonDbContext db)
        {
            _logger = logger;
            dataContext = db;

        }
       
        public IActionResult Index()
        {
            return View(dataContext.Users);
        }
        public IActionResult AdminApproved()
        {
            return View(dataContext.Users);
        }
        public IActionResult AllUser()
        {
            return View(dataContext.Users);
        }
        public IActionResult CreateAssignment()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Sign()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        public IActionResult Assign_Assignment()
        {
            return View();
        }
      
        public IActionResult Signup_as_Student()
        {
            return View();
        }
        public IActionResult FrontPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(User user)
        {
            if(ModelState.IsValid)
            {
                dataContext.Add(user);
                dataContext.SaveChanges();
                return View("Sign");
            }
            else

            return View();
        }

        [HttpPost]
        public IActionResult Sign(UserLogin userinfo)
        {
            var user = dataContext.Users.Where(a => (a.email == userinfo.email) &&  (a.password == userinfo.password));
            if (user.Count() == 0)
            {
                //Login Unsuccessful
                return RedirectToAction("UsersNotfound");
            }
            else
            {
                // Login Success
                return RedirectToAction("Index");
            }
        }
        public IActionResult UsersNotfound()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            return View(dataContext.Users.Where(a => a.id == id).FirstOrDefault());
        }
        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_post(User User)
        {
            dataContext.Users.Update(User);
            dataContext.SaveChanges();
            return View("Index");
        }
       
        public IActionResult Delete(int id)
        {
            var user = dataContext.Users.Where(a => a.id == id).FirstOrDefault();
            dataContext.Users.Remove(user);
            dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
        
}
