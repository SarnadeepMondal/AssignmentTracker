﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebApplication.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        
        

    }
}
