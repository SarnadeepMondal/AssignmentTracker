using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TestWebApplication.Data;
using TestWebApplication.Models;
using TestWebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Http;

namespace TestWebApplication.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;
        private ApplicatonDbContext dataContext;
        private IHostingEnvironment _env;
        const string name = "_name";
        public DashboardController(ILogger<DashboardController> logger, ApplicatonDbContext db, IHostingEnvironment env)
        {
            _logger = logger;
            dataContext = db;
            _env = env;

        }
        //public IActionResult Index()
        //{
        //    string AssignmentDoc = (from a in dataContext.Assignments
        //                            where a.StudentId == 2
        //                            select a.AssignmentDoc).FirstOrDefault();


        //    int StudentId = 2;
        //    var UploadAssignmentDetails = from usr in dataContext.Users
        //                                  join aa in dataContext.AssignAssignments on usr.id equals aa.StudentId
        //                                  join a in dataContext.Assignments on aa.AssignAssignmentId equals a.AssignmentID
        //                                  where usr.id == StudentId
        //                                  select new UploadAssignmentViewModel()
        //                                  {
        //                                      Id = usr.id,
        //                                      AssignmentName = a.AssignmentName,
        //                                      AssignmentDescription = a.AssignmentDescription,
        //                                      AssignmentDoc = a.AssignmentDoc,
        //                                      SubmissionDate = a.SubmissionDate,
        //                                  };


        //    TempData["AssignmentDoc"] = AssignmentDoc;

        //    ViewBag.Name = HttpContext.Session.GetString(name);

        //    TempData["Teacher"] = "Teacher";
        //    TempData["Student"] = "Student";
        //    TempData["Admin"] = "Admin";
        //    return View();
        //}

        // [Route("Dashboard/Index/{id:int}")]
        public IActionResult Index(int id)
        {

            //int StudentId = 2;
            var UploadAssignmentDetails = from usr in dataContext.Users
                                          join aa in dataContext.AssignAssignments on usr.id equals aa.StudentId
                                          join a in dataContext.Assignments on aa.AssignAssignmentId equals a.AssignmentID
                                          where usr.id == id
                                          select new UploadAssignmentViewModel()
                                          {
                                              Id = usr.id,
                                              AssignmentName = a.AssignmentName,
                                              AssignmentDocName = a.AssignmentDocName,
                                              AssignmentDescription = a.AssignmentDescription,
                                              AssignmentDoc = a.AssignmentDoc,
                                              SubmissionDate = a.SubmissionDate,
                                          };


            // TempData["AssignmentDoc"] = AssignmentDoc;

            ViewBag.Name = HttpContext.Session.GetString(name);

            TempData["Teacher"] = "Teacher";
            TempData["Student"] = "Student";
            TempData["Admin"] = "Admin";
            return View(UploadAssignmentDetails);
        }

        [HttpPost]
        public IActionResult Index(StudentAssignment Student, IFormFile file)
        {

            #region Studentdetails
            int std = 1;
            var stddetails = from usr in dataContext.Users
                             join aa in dataContext.AssignAssignments on usr.id equals aa.StudentId
                             join a in dataContext.Assignments on aa.AssignAssignmentId equals a.AssignmentID
                             where usr.id == std
                             select new StudentAssignmentViewModel()
                             {
                                 Id = usr.id,// stu id
                                 AssignmentId = a.AssignmentID,
                                 AssignmentName = a.AssignmentName,
                                 AssignmentDescription = a.AssignmentDescription,
                                 AssignmentDoc = a.AssignmentDoc,
                                 SubmissionDate = a.SubmissionDate,
                             };

            #endregion

            var fileName = System.IO.Path.GetFileName(file.FileName);
            var AnswerDoct = System.IO.Path.Combine(_env.WebRootPath, "UploadAssignment", fileName);
            if (file.Length > 0)
            {
                using (var stream = new FileStream(AnswerDoct, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
            }
            Student.StudentId = 1; //
            Student.AssignmentId = 2; //
            Student.Documents = "TestDoc";
            Student.AnswerDoc = AnswerDoct; // Answer uplaod by student
            Student.SubmissionDate = DateTime.Now;
            dataContext.Add(Student);
            dataContext.SaveChanges();
            return RedirectToAction("AssignAssignment", "Dashboard");
        }

        [HttpPost]
        public IActionResult Index1(StudentAssignment Student, IFormFile file)
        {

            #region Studentdetails
            int std = 1;
            var stddetails = from usr in dataContext.Users
                             join aa in dataContext.AssignAssignments on usr.id equals aa.StudentId
                             join a in dataContext.Assignments on aa.AssignAssignmentId equals a.AssignmentID
                             where usr.id == std
                             select new StudentAssignmentViewModel()
                             {
                                 Id = usr.id,// stu id
                                 AssignmentId = a.AssignmentID,
                                 AssignmentName = a.AssignmentName,
                                 AssignmentDescription = a.AssignmentDescription,
                                 AssignmentDoc = a.AssignmentDoc,
                                 SubmissionDate = a.SubmissionDate,
                             };

            #endregion

            var fileName = System.IO.Path.GetFileName(file.FileName);
            var AnswerDoct = System.IO.Path.Combine(_env.WebRootPath, "UploadAssignment", fileName);
            if (file.Length > 0)
            {
                using (var stream = new FileStream(AnswerDoct, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
            }
            Student.StudentId = 1; //
            Student.AssignmentId = 2; //
            Student.Documents = "TestDoc";
            Student.AnswerDoc = AnswerDoct; // Answer uplaod by student
            Student.SubmissionDate = DateTime.Now;
            dataContext.Add(Student);
            dataContext.SaveChanges();
            return RedirectToAction("AssignAssignment", "Dashboard");
        }

        public IActionResult AdminApproved()
        {
            TempData["Teacher"] = "Teacher";
            TempData["Student"] = "Student";
            TempData["Admin"] = "Admin";
            return View(dataContext.Users.Where(a => a.isApproved != true));
        }

        public IActionResult CreateAssignment()
        {
            TempData["Teacher"] = "Teacher";
            TempData["Student"] = "Student";
            TempData["Admin"] = "Admin";
            return View();
        }
        [HttpPost]
        public IActionResult CreateAssignment(Assignment assignment, IFormFile file)
        {
            var fileName = System.IO.Path.GetFileName(file.FileName);
            var filePath = System.IO.Path.Combine(_env.WebRootPath, "file", fileName);
            if (file.Length > 0)
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
            }
            assignment.AssignmentDocName = fileName;
            assignment.AssignmentDoc = filePath;
            assignment.SubmissionDate = DateTime.Now.Date;

            dataContext.Add(assignment);
            dataContext.SaveChanges();
            return RedirectToAction("AssignAssignment", "Dashboard");

        }

        [HttpGet]
        public ActionResult GetPdf(string fileName)
        {
            string filePath = "~/file/" + fileName;
            Response.Headers.Add("Content-Disposition", "inline; filename=" + fileName);
            return File(filePath, "application/pdf");
        }
        public IActionResult AllUser()
        {
            TempData["Teacher"] = "Teacher";
            TempData["Student"] = "Student";
            TempData["Admin"] = "Admin";
            return View(dataContext.Users.Where(a => a.UserType != "Admin" && a.isDelete == false));

        }
        public IActionResult AssignAssignment()
        {
            #region Assignment_DropDown_Section

            List<Department> deptList = new List<Department>();
            deptList = (from Departments in dataContext.Departments
                        select Departments).ToList();

            List<Assignment> AssignmentList = new List<Assignment>();
            AssignmentList = (from Assignment in dataContext.Assignments
                              select Assignment).ToList();

            #endregion
            ViewBag.listofAssignment = AssignmentList;
            ViewBag.listofDept = deptList;
            return View();
        }

        [HttpPost]
        public IActionResult AssignAssignment(AssignAssignment TaskAsg)
        {
            List<User> userlist = new List<User>();
            userlist = dataContext.Users.Where(x => x.DepartmentId == 1 && x.BranchId == TaskAsg.BranchId && x.Semester == TaskAsg.SemesterId).ToList();

            for (int i = 0; i < userlist.Count; i++)
            {
                TaskAsg.AssignAssignmentId = userlist[i].id;
                TaskAsg.DepartmentId = 1; // This Need to be updated.
                TaskAsg.SubmitStatus = false;
                TaskAsg.StudentId = userlist[i].id;
                dataContext.Add(TaskAsg);
                dataContext.SaveChanges();
            }

            return RedirectToAction("AssignAssignment", "Dashboard");
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
            GetAssignment();
            var SemesterList = new SelectList(dataContext.Semesters.Where(c => c.BranchId == Branchid), "SemesterId", "SemesterName");
            return Json(SemesterList);
        }

        [HttpGet]
        public JsonResult GetAssignment()
        {
            var SubjectsList = new SelectList(dataContext.Subjects.ToList(), "SubjectId", "SubjectName");
            return Json(SubjectsList);

        }

        public IActionResult Approved(int id)
        {
            var user = dataContext.Users.Where(a => a.id == id).FirstOrDefault();
            user.isApproved = true;
            dataContext.Users.Update(user);
            dataContext.SaveChanges();
            return RedirectToAction("AdminApproved");
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
            return View("AllUser");
        }

        public IActionResult Delete(int id)
        {
            // For Delete only update the IsDelete coulum as true
            var user = dataContext.Users.Where(a => a.id == id && a.isApproved == true).FirstOrDefault();
            user.isDelete = true;
            dataContext.Users.Update(user);
            dataContext.SaveChanges();
            return RedirectToAction("AllUser");
        }
        public IActionResult TeachersDashboard()
        {
            var AssignmentList = from usr in dataContext.Users
                                 join dpt in dataContext.Departments on usr.DepartmentId equals dpt.DepartmentId
                                 join brn in dataContext.Branchs on usr.BranchId equals brn.BranchId
                                 join sem in dataContext.Semesters on usr.Semester equals sem.SemesterId
                                 join aa in dataContext.AssignAssignments on usr.id equals aa.StudentId
                                 join asg in dataContext.Assignments on aa.AssignAssignmentId equals asg.AssignmentID
                                 // skip the choose Assignments row and display submited Assignments only
                                 where asg.AssignmentID != 1 && aa.SubmitStatus ==true 
                                 join sta in dataContext.StudentAssignments on aa.StudentId equals sta.StudentId 
                                 select new AssignmentViewModel()
                                 {
                                     StudentId = usr.id,
                                     Name = usr.name,
                                     Department = dpt.DepartmentName,
                                     Branch = brn.BranchName,
                                     Semester = sem.SemesterName,
                                     Assignment = asg.AssignmentName,
                                     DocName = sta.AnswerDocName
                                 };
            //TempData["Teacher"] = "NA";
            //TempData["Admin"] = "NA";
            //TempData["Student"] = "NA";
            return View(AssignmentList);
        }

        //[HttpPost]
        //public JsonResult SaveProjectAssignment(int StudentId, string datetime, IFormFile Fileassignmentdoc )
        //{
        //   //code for save
        //}
        //public IActionResult StudentsSubmission(int id)
        //{
        //    return View("StudentsSubmission");
        //}

        public IActionResult StudentsSubmission(int id)
        {
            return View(dataContext.Users.Where(a => a.id == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("StudentsSubmission")]
        public IActionResult Submission_post(User User, IFormFile file)
        {
            StudentAssignment Student = new StudentAssignment();

            #region Studentdetails
            int std = User.id;
            var stddetails = from usr in dataContext.Users
                             join aa in dataContext.AssignAssignments on usr.id equals aa.StudentId
                             join a in dataContext.Assignments on aa.AssignAssignmentId equals a.AssignmentID
                             where usr.id == std
                             select new StudentAssignmentViewModel()
                             {
                                 Id = usr.id,// stu id
                                 AssignmentId = a.AssignmentID,
                                 AssignmentName = a.AssignmentName,
                                 AssignmentDescription = a.AssignmentDescription,
                                 AssignmentDoc = a.AssignmentDoc,
                                 SubmissionDate = a.SubmissionDate,
                             };

            #endregion

            var fileName = System.IO.Path.GetFileName(file.FileName);// Get file name
            var AnswerDoct = System.IO.Path.Combine(_env.WebRootPath, "UploadAssignment", fileName); // Location
            if (file.Length > 0)
            {
                using (var stream = new FileStream(AnswerDoct, FileMode.Create))
                {
                    file.CopyToAsync(stream);
                }
            }

            #region getAssignmentDetails
            // AssignAssignmentId from AssignAssignment tbl by student id

            string _AssignAssignmentId = (from a in dataContext.AssignAssignments
                                          where a.AssignAssignmentId == std
                                          select a.AssignAssignmentId).FirstOrDefault().ToString();
            string _AssignDepartmentId = (from a in dataContext.AssignAssignments
                                          where a.AssignAssignmentId == std
                                          select a.DepartmentId).FirstOrDefault().ToString();
            string _AssignBranchId = (from a in dataContext.AssignAssignments
                                          where a.AssignAssignmentId == std
                                          select a.BranchId).FirstOrDefault().ToString();
            string _AssignSemesterId = (from a in dataContext.AssignAssignments
                                      where a.AssignAssignmentId == std
                                      select a.SemesterId).FirstOrDefault().ToString();

            // Assignment doc name by teacher 

            string AssignmentDocName = (from an in dataContext.Assignments
                                          where an.AssignmentID == Convert.ToInt32( _AssignAssignmentId)
                                          select an.AssignmentDocName).FirstOrDefault().ToString();
            #endregion

            #region SaveAssignmentBlock

            AssignAssignment Assign = new AssignAssignment();
            Assign.AssignAssignmentId = Convert.ToInt32( _AssignAssignmentId);
            Assign.SubmitStatus = true;
            Assign.DepartmentId = Convert.ToInt32(_AssignDepartmentId);
            Assign.BranchId = Convert.ToInt32(_AssignBranchId);
            Assign.SemesterId = Convert.ToInt32(_AssignSemesterId);
            Assign.StudentId = std;
            dataContext.AssignAssignments.Update(Assign);
            dataContext.SaveChanges();

            #endregion

            #region SaveStudentBlock

            Student.StudentId = std; //
            Student.AssignmentId = Convert.ToInt32(_AssignAssignmentId); //
            Student.Documents = AssignmentDocName;
            Student.AnswerDoc = AnswerDoct; // Answer uplaod by student
            Student.AnswerDocName = fileName; // student uplaod fileName 
            Student.Description = "NA"; // Not Saving the description.
            Student.SubmissionDate = DateTime.Now;
            dataContext.StudentAssignments.Update(Student);
            dataContext.SaveChanges();

            #endregion

            return RedirectToAction("Index", "Dashboard", new { id = User.id });
        }

        public IActionResult ViewerNewTab(string filename)
        {
            string path = _env.WebRootPath + "\\file\\" + filename;
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }
        public IActionResult ViewerNewTab1(string filename)
        {
            string path = _env.WebRootPath + "\\UploadAssignment\\" + filename;
            return File(System.IO.File.ReadAllBytes(path), "application/pdf");
        }

    }
}
    
    