using SchoolWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApiDemo.Data
{
    public class MockStudentRepository : IStudentRepository
    {
        private readonly List<Student> Students = new List<Student>()
       {
           new Student()
           {
            StudentId=Guid.NewGuid(),
            FirstName="Mohammed",
            LastName="Adem"
           },
            new Student()
           {
            StudentId=Guid.NewGuid(),
            FirstName="Tuha",
            LastName="Ahmed"
           },
             new Student()
           {
            StudentId=Guid.NewGuid(),
            FirstName="Mayuri",
            LastName="Vaidiya"
           },
              new Student()
           {
            StudentId=Guid.NewGuid(),
            FirstName="Daniel",
            LastName="Zemo"
           },
               new Student()
           {
            StudentId=Guid.NewGuid(),
            FirstName="Sejal",
            LastName="Dave"
           }
       };
        public Student AddStudent(Student student)
        {
            student.StudentId = Guid.NewGuid();
            Students.Add(student);
            return student;
        }

        public void DeleteStudent(Student student)
        {
            Students.Remove(student);
        }

        public List<Student> GetAllStudent()
        {
            return Students;
        }

        public Student GetStudent(Guid Id)
        {
          return  Students.FirstOrDefault(p => p.StudentId == Id);
        }

        public Student UpdateStudent(Student student)
        {
            var ExistingStudent = GetStudent(student.StudentId);
            ExistingStudent.FirstName = student.FirstName;
            ExistingStudent.LastName = student.LastName;
            return ExistingStudent;
        }
    }
}
