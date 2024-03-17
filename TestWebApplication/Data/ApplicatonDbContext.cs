using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Models;

namespace TestWebApplication.Data
{
    public class ApplicatonDbContext : DbContext
    {
        public ApplicatonDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users {get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AssignAssignment> AssignAssignments { get; set; }
        public DbSet<StudentAssignment> StudentAssignments { get; set; }

    }
}
