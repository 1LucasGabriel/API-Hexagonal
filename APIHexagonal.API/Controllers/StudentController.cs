using APIHexagonal.Application.DTOs;
using APIHexagonal.Application.Interfaces.IServices;
using APIHexagonal.Application.Services;
using APIHexagonal.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIHexagonal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        protected readonly IStudentService _studentService;
        public StudentController(IStudentService service)
        {
            _studentService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var student = _studentService.GetById(id);

            if (student == null) 
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(CreateStudentDTO student)
        {
            _studentService.Create(student);
            return Created();
        }

        [HttpPost("enroll")]
        public IActionResult Enroll([FromBody] CreateEnrollDTO enroll)
        {
            var result = _studentService.Enroll(enroll.IdStudent, enroll.IdCourse);

            if (!result) 
                return BadRequest("Enrollment failed.");

            return Ok("Enrollment successful.");
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CreateStudentDTO student)
        {
            var result = _studentService.Update(id, student);

            if (!result) 
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _studentService.Delete(id);

            if (!result) 
                return NotFound();

            return NoContent();
        }
    }
}
