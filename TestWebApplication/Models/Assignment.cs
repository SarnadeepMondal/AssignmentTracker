using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class Assignment
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AssignmentID { get; set; }
        [Required(ErrorMessage = "Please enter Assignment name")]
        public string AssignmentName { get; set; }
        [Required(ErrorMessage = "Please enter Assignment Description")]
        public string AssignmentDescription { get; set; }
        public string AssignmentDoc { get; set; }
        public string AssignmentDocName { get; set; }
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Please enter Assignment Submission date")]
        public DateTime SubmissionDate  { get; set; }
        public int StudentId { get; set; }

    }
}
