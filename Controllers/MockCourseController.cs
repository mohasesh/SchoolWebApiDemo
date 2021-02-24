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
    [Route("api/Course")]
    [ApiController]
    public class MockCourseController : ControllerBase
    {
        private readonly ICourseRepository _IcourseRepository;
        public MockCourseController(ICourseRepository CourseRepository)
        {
            _IcourseRepository = CourseRepository;
        }
      [HttpGet]
      [Route("GetAllCourses")]
      public IActionResult GetAllCourses()
        {
            var Courses = _IcourseRepository.GetAllCourses();
           if(Courses==null)
            {
            return NotFound();
            }
            return Ok(Courses);
        }
        [HttpGet]
        [Route("GetCourse/{Code}")]
        public IActionResult GetCourse(string Code)
        {
            var Course = _IcourseRepository.GetCourse(Code);
            if(Course==null)
            {
                return NotFound($"The following Course Information with this :{Code} is not found");
            }
            return Ok(Course);
        }
        [HttpPost]
        [Route("AddCourse")]
        public IActionResult AddCourse(Course Course)
        {
            var MyCourse = _IcourseRepository.AddCourse(Course);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + Course.CourseCode,MyCourse);
        }
        [HttpDelete]
        [Route("DeleteCourse/{CCode}")]
        public IActionResult DeleteCourse(string CCode)
        {
            var DelCourse = _IcourseRepository.GetCourse(CCode);
            if(DelCourse!=null)
            {
                _IcourseRepository.DeleteCourse(DelCourse);
                return Ok();
            }
            return NotFound($"There is no record found with this Id:{CCode}");
        }
        [HttpPut]
        [Route("UpdateCourse/{CCode}")]
        public IActionResult UpdateCourse(string CCode,Course Course)
        {
            var PutCourse = _IcourseRepository.GetCourse(CCode);
            if (PutCourse != null)
            {
                Course.CourseCode = PutCourse.CourseCode;
                _IcourseRepository.UpdateCourse(Course);
               
            }
            return Ok(PutCourse);
        }
    }
}
