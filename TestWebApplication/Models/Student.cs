using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int departmentID{ get; set; }
        public int branchID { get; set; }
        public int semesterID{ get; set; }
        public string phone_no { get; set; }
    }
}
