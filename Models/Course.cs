using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace SchoolWebApiDemo.Models
{
    public class Course
    { 
        [Key]
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        
        public int CreditHour { get; set; }
        public ICollection<Enrollement> Enroll { get; set; }

    }
}
