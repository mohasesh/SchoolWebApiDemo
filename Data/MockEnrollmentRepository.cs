using SchoolWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApiDemo.Data
{
    public class MockEnrollmentRepository:IEnrollmentRepository
    {
     private readonly   List<Enrollement> Enrollments = new List<Enrollement>()
        {
            new Enrollement()
            {
                EnrollId=1,
                StudentId=Guid.Parse("df01243a-b341-4d7b-9d03-217d421a6467"),
                CourseCode="NET.022"
                
            },
            new Enrollement()
            {
                EnrollId=1,
                StudentId=Guid.Parse("df01243a-b341-4d7b-9d03-217d421a6467"),
                CourseCode="NET.032"
            }
        };
        public Enrollement AddEnrollment(Enrollement Enrollment)
        {
            Enrollments.Add(Enrollment);
            return Enrollment;
        }

        public Enrollement DeleteEnrollment(Enrollement Enrollment)
        {
            Enrollments.Remove(Enrollment);
            return Enrollment;
        }

        public List<Enrollement> GetAllEnrollment()
        {
            return Enrollments;
        }

        public Enrollement GetEnrollment(int Id)
        {
          return  Enrollments.FirstOrDefault(p => p.EnrollId == Id);

        }

        public Enrollement UpdateEnrollment(Enrollement Enrollment)
        {
            var ExistngEnroll = GetEnrollment(Enrollment.EnrollId);
            ExistngEnroll.CourseCode = Enrollment.CourseCode;
            ExistngEnroll.StudentId = Enrollment.StudentId;
            return ExistngEnroll;
        }
    }
}
