using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApiDemo.Models
{
    public class Enrollement
    {
        [Key]
        public int EnrollId { get; set; }
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
        public string CourseCode { get; set; }
        public Course Course { get; set; }
    }
}
