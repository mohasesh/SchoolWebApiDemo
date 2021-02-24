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
    [Route("api/Student")]
    [ApiController]
    public class MockStudentController : ControllerBase
    {
        private readonly IStudentRepository _StudentRepository;
        public MockStudentController(IStudentRepository StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }
        [HttpGet]
        [Route("GetAllStudents")]
       public IActionResult GetAllStudent()
        {
            var Students = _StudentRepository.GetAllStudent();
            if (Students == null)
            {
                return NotFound();

            }
            return Ok(Students);
        }
        [HttpGet]
        [Route("GetStudent/{Id}")]
        public IActionResult GetStudent(Guid Id)
        {
            var Student = _StudentRepository.GetStudent(Id);
            if (Student == null)
            {
                return NotFound($"The Following student Id:{Id} : not found");

            }
            return Ok(Student);
        }
        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent(Student Student)
        {
            _StudentRepository.AddStudent(Student);
            return Created(HttpContext.Request.Scheme+"://"+HttpContext.Request.Host+HttpContext.Request.Path+"/"+Student.StudentId,Student);
        }
        [HttpDelete]
        [Route("DeleteStudent/{Id}")]
        public IActionResult DeleteStudent(Guid Id)
        {
           var DelStudent= _StudentRepository.GetStudent(Id);
            if(DelStudent!=null)
            {
             _StudentRepository.DeleteStudent(DelStudent);
                return Ok();
            }
            return NotFound($"The following Id:{Id} : is  not Found");
        }
        [HttpPut]
        [Route("UpdateStudent/{Id}")]
        public IActionResult UpdateStudent(Guid Id,Student Student)
        {
            var ExistingStudent = _StudentRepository.GetStudent(Id);
            if (ExistingStudent != null)
            {
                Student.StudentId = ExistingStudent.StudentId;
                _StudentRepository.UpdateStudent(Student);
                
            }
            return Ok(Student);
        }
    }
}
