using Microsoft.EntityFrameworkCore;
using SchoolWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApiDemo.Data
{
    public class SchoolContext:DbContext
    {
        
        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
        {
          
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Enrollement> Enroll { get; set; }

    }
}
