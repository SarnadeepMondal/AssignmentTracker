using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models.ViewModel
{
    public class AssignmentViewModel
    {
        private int studentId;
        private string name;
        private string department;
        private string branch;
        private string semester;
        private string assignment;
        private string docName;

        public AssignmentViewModel()
        {

        }
        public AssignmentViewModel (int studentId, string name, string department, string branch, string semester, string assignment, string docName)
        {
            this.studentId = studentId;
            this.name = name;
            this.department = department;
            this.branch = branch;
            this.semester = semester;
            this.assignment = assignment;
            this.docName = docName;
        }
        public int StudentId 
        {
            get { return studentId; }
            set { studentId = value; }
         }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public string Branch
        {
            get { return branch; }
            set { branch = value; }
        }
        public string Semester
        {
            get { return semester; }
            set { semester = value; }
        }
        public string Assignment
        {
            get { return assignment; }
            set { assignment = value; }

        }
        public string DocName
        {
            get { return docName; }
            set { docName = value; }
        }
    }
}
