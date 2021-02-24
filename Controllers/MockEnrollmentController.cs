using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWebApiDemo.Data;
using SchoolWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolWebApiDemo.Controllers
{
    [Route("api/Enrollment")]
    [ApiController]
    public class MockEnrollmentController : ControllerBase
    {
        private readonly IEnrollmentRepository _EnrollRepository;
        public MockEnrollmentController(IEnrollmentRepository EnrollRepo)
        {
            _EnrollRepository = EnrollRepo;
        }
        [HttpGet]
        [Route("GetAllEnrolled")]
        public IActionResult GetAllCoursesGetAllEnrollment()
        {
            var Enrollements = _EnrollRepository.GetAllEnrollment();
            if (Enrollements == null)
            {
                return NotFound();
            }
            return Ok(Enrollements);
        }
        [HttpGet]
        [Route("GetCourse/{EnrollId}")]
        public IActionResult GetEnrollment(int EnrollId)
        {
            var Enroll = _EnrollRepository.GetEnrollment(EnrollId);
            if (Enroll == null)
            {
                return NotFound($"The following Course Information with this :{EnrollId} is not found");
            }
            return Ok(Enroll);
        }
        [HttpPost]
        [Route("AddEnrollment")]
        public IActionResult AddEnrollment(Enrollement Enrollment)
        {
            var Enroll = _EnrollRepository.AddEnrollment(Enrollment);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + Enroll.CourseCode, Enroll);
        }
        [HttpDelete]
        [Route("DeleteEnrollement/{EnrollId}")]
        public IActionResult DeleteCourse(int EnrollId)
        {
            var DelEnroll = _EnrollRepository.GetEnrollment(EnrollId);
            if (DelEnroll != null)
            {
                _EnrollRepository.DeleteEnrollment(DelEnroll);
                return Ok();
            }
            return NotFound($"There is no record found with this Id:{EnrollId}");
        }
        [HttpPut]
        [Route("UpdateEnrollement/{EnrollId}")]
        public IActionResult UpdateCourse(int EnrollId,Enrollement Enrollment)
        {
            var PutEnroll = _EnrollRepository.GetEnrollment(EnrollId);
            if (PutEnroll != null)
            {
                Enrollment.CourseCode = PutEnroll.CourseCode;
               _EnrollRepository.UpdateEnrollment(Enrollment);
            }
            return Ok(PutEnroll);
        }
    }
}
