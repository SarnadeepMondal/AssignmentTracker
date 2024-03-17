using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class StudentAssignment
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StudentAssignmentId { get; set; }
        public int StudentId { get; set; }
        public int AssignmentId { get; set; }
        public string Description { get; set; }
        public string Documents { get; set; }
        public string AnswerDoc { get; set; }
        public string AnswerDocName { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
