using SchoolWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApiDemo.Data
{
   public  interface IEnrollmentRepository
    {
        public List<Enrollement> GetAllEnrollment();
        public Enrollement GetEnrollment(int Id);
        public Enrollement AddEnrollment(Enrollement Enrollment);
        public Enrollement DeleteEnrollment(Enrollement Enrollment);
        public Enrollement UpdateEnrollment(Enrollement Enrollment);

    }
}
