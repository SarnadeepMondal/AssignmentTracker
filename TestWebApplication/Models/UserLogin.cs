using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class UserLogin
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
