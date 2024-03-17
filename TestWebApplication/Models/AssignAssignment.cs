using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class AssignAssignment
    {
        
        public int AssignAssignmentId { get; set; }
        [Required(ErrorMessage = "Please choose Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please choose Branch")]
        public int BranchId { get; set; }
        [Required(ErrorMessage = "Please choose Semester")]
        public int SemesterId { get; set; }
        [Required(ErrorMessage = "Please choose Assignment")]
        public int AssignmentId { get; set; }
        public bool SubmitStatus { get; set; }
        public int StudentId { get; set; }
    }
}
