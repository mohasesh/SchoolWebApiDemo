using SchoolWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApiDemo.Data
{
    public class MockCourseRepository : ICourseRepository
    {
      private  readonly List<Course> Courses = new List<Course>()
        {
        new Course()
        {
            CourseCode="NET.022",
            CourseTitle="ASP.NET Web Application ",
            CreditHour=3
        },
         new Course()
        {
            CourseCode="NET.032",
            CourseTitle="Dev Distributed ",
            CreditHour=4
        }
        };
        public Course AddCourse(Course Course)
        {
           Courses.Add(Course);
            return Course;
        }

        public void DeleteCourse(Course Course)
        {
            Courses.Remove(Course);
        }

        public List<Course> GetAllCourses()
        {
            return Courses;
        }

        public Course GetCourse(string CCode)
        {
            var Course = Courses.FirstOrDefault(p => p.CourseCode == CCode);
            return Course;
        }

        public Course UpdateCourse(Course Course)
        {
            var ExistingCourse = GetCourse(Course.CourseCode);
            ExistingCourse.CourseTitle = Course.CourseTitle;
            ExistingCourse.CreditHour = Course.CreditHour;
            return ExistingCourse;
        }

      
    }
}
