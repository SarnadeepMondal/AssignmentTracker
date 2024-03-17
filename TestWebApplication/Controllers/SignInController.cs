using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Data;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    
    public class SignInController : Controller
    {
        private readonly ILogger<SignInController> _logger;
        private ApplicatonDbContext dataContext;
        public const string Name = "_UserName";
        public const string AdminUseremail = "_AdminUseremail";
        public SignInController(ILogger<SignInController> logger, ApplicatonDbContext db)
        {
            _logger = logger;
            dataContext = db;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        private void SetValue(string name, string useremail)
        {
            HttpContext.Session.SetString(AdminUseremail, useremail);
            HttpContext.Session.SetString(Name, name);

            TempData["UserName"] = HttpContext.Session.GetString(Name);
            TempData["AdminUseremail"] = HttpContext.Session.GetString(AdminUseremail);
        }
        
        [HttpPost]
        public IActionResult SignIn(User userinfo)
        {
            var user = dataContext.Users.Where(a => (a.email == userinfo.email) && (a.password == userinfo.password) && (a.UserType == "Admin"));
            var user1 = dataContext.Users.Where(a => (a.email == userinfo.email) && (a.password == userinfo.password) && (a.UserType == "Teacher") && (a.isApproved == true));
            var user2 = dataContext.Users.Where(a => (a.email == userinfo.email) && (a.password == userinfo.password) && (a.UserType == "Student") && (a.isApproved == true));
            #region Login Rule

            TempData["Teacher"] = "NA";
            TempData["Admin"] = "NA";
            TempData["Student"] = "NA";
            // If Admin
            if (user.Any())
            {
                if (user.Count() == 0)
                {
                    //Login Unsuccessful
                    return RedirectToAction("UsersNotfound", "NotFound");
                }
                else
                {
                    // Login Success

                    #region UserdetailsBlock
                    string userName = (from u in user
                                    where u.email == userinfo.email && u.password == userinfo.password && u.UserType == "Admin"
                                    select u.name).FirstOrDefault();

                    string useremail = (from u in user
                                      where u.email == userinfo.email && u.password == userinfo.password && u.UserType == "Admin"
                                           select u.email).FirstOrDefault();
                    string Userid = (from u in user
                                        where u.email == userinfo.email && u.password == userinfo.password && u.UserType == "Admin"
                                        select u.id).FirstOrDefault().ToString();

                    SetValue(userName, useremail);

                    #endregion

                     TempData["Admin"] = "Admin";
                    //return RedirectToAction("Index", "Dashboard");
                    return RedirectToAction("Index", "Dashboard", new { id = Userid });
                }
            }
            // If Teacher
            else if (user1.Any())
            {
                var teacher = dataContext.Users.Where(a => (a.email == userinfo.email) && (a.password == userinfo.password) && (a.UserType == "Teacher"));
                if (teacher.Count() == 0)
                {
                    //Login Unsuccessful
                    return RedirectToAction("UsersNotfound");
                }
                else
                {
                    // Login Success
                    string Userid = (from u in user1
                                     where u.email == userinfo.email && u.password == userinfo.password && u.UserType == "Teacher"
                                     select u.id).FirstOrDefault().ToString();

                    TempData["Teacher"] = "Teacher";
                    TempData["Admin"] = "NotAdmin";
                    return RedirectToAction("Index", "Dashboard", new { id = Userid });
                }

            }
            //If Student
            else if (user2.Any())
            {
                var Student = dataContext.Users.Where(a => (a.email == userinfo.email) && (a.password == userinfo.password) && (a.UserType == "Student"));
                if (user2.Count() == 0)
                {
                    //Login Unsuccessful
                    return RedirectToAction("UsersNotfound");
                }
                else
                {
                    // Login Success
                    string Userid = (from u in user2
                                     where u.email == userinfo.email && u.password == userinfo.password && u.UserType == "Student"
                                     select u.id).FirstOrDefault().ToString();
                    TempData["Student"] = "Student";
                    TempData["Admin"] = "NotAdmin";
                   // return RedirectToAction("Index", "Dashboard", ViewBag.Student);
                    return RedirectToAction("Index", "Dashboard", new { id = Userid });
                }

            }
            else
            {
                return RedirectToAction("UsersNotfound");
                // Invalid User
            }

            #endregion
        }

        public IActionResult SignOut()
        {
            return RedirectToAction("SignIn");
        }
    }
}
