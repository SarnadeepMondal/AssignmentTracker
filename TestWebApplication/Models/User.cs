using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class User
    {
      
        [Key]
        public int id { get; set; }
       
        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string email { get; set; }
     
        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public string UserType { get; set; }
        public Boolean isApproved { get; set; }
        public Boolean isDelete { get; set; }
        public int DepartmentId { get; set; }
        public int BranchId { get; set; }
        public int Semester { get; set; }

    }
}
