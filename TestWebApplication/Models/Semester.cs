using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class Semester
    {
        [Key]
        public int SemesterId { get; set; }
        [Required]
        public string SemesterName { get; set; }
        [Required]
        [ForeignKey("BranchFK")]
        public int BranchId { get; set; }
    }
}
