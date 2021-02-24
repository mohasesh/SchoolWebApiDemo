using SchoolWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApiDemo.Data
{
  public  interface ICourseRepository
    {
    public List<Course> GetAllCourses();
    public Course GetCourse(string CCode);
    public Course AddCourse(Course Course);
    public void DeleteCourse(Course Course);
    public Course UpdateCourse(Course Course);
    }
}
