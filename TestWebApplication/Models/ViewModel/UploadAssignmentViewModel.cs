using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models.ViewModel
{
    public class UploadAssignmentViewModel
    {
        public UploadAssignmentViewModel()
        {

        }
       
        public int Id { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDoc { get; set; }
        public string AssignmentDocName { get; set; }
        public string AssignmentDescription { get; set; }
        public DateTime SubmissionDate { get; set; }
    }

    public class StudentAssignmentViewModel
    {
        public StudentAssignmentViewModel()
        {

        }
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDoc { get; set; }
        public string AssignmentDescription { get; set; }
        public DateTime SubmissionDate { get; set; }
    }


}
