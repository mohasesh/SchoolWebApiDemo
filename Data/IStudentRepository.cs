using SchoolWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApiDemo.Data
{
   public interface IStudentRepository
    {
     public  List<Student> GetAllStudent();
     public Student GetStudent(Guid Id);
     public Student AddStudent(Student student);
     public void DeleteStudent(Student student);
     public Student UpdateStudent(Student student);
    }
}
