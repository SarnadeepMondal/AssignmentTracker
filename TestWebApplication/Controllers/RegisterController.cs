using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Data;
using TestWebApplication.Models;

namespace TestWebApplication.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ILogger<RegisterController> _logger;
        private ApplicatonDbContext dataContext;
        public RegisterController(ILogger<RegisterController> logger, ApplicatonDbContext db)
        {
            _logger = logger;
            dataContext = db;
        }
        public IActionResult Student()
        {
            List<Department> deptList = new List<Department>();
            deptList = (from Departments in dataContext.Departments
                        select Departments).ToList();

            ViewBag.listofDept = deptList;

            return View();
        }
        [HttpPost]
        public IActionResult Student(User user)
        {
            user.UserType = "Student";
            user.DepartmentId = 1;
            string vend = Convert.ToString((from user1 in dataContext.Users
                                            where user1.email == user.email
                                            select user1.email).FirstOrDefault());

            if (vend == null)
            {
                if (ModelState.IsValid)
                {
                    dataContext.Add(user);
                    dataContext.SaveChanges();
                    return RedirectToAction("SignIn", "SignIn");
                }
                else
                {
                    return RedirectToAction("SignIn", "SignIn");
                }

            }
            else
            {
                return RedirectToAction("SignIn", "SignIn");
            }

            
        }
        public IActionResult Teacher()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Teacher(User user)
        {
            user.UserType = "Teacher";
            if (ModelState.IsValid)
            {
                dataContext.Add(user);
                dataContext.SaveChanges();
                return RedirectToAction("SignIn", "SignIn");
            }
            else

                return View();
        }

        [HttpGet]
        public JsonResult GetBranchsList(int DepartId)
        {
            var BranchsList = new SelectList(dataContext.Branchs.Where(c => c.DepartmentId == DepartId), "BranchId", "BranchName");
            return Json(BranchsList);

        }
        [HttpGet]
        public JsonResult GetSemesterList(int Branchid)
        {
            var SemesterList = new SelectList(dataContext.Semesters.Where(c => c.BranchId == Branchid), "SemesterId", "SemesterName");
            return Json(SemesterList);
        }


    }
}
