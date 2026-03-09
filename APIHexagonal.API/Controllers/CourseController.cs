using APIHexagonal.Application.DTOs;
using APIHexagonal.Application.Interfaces.IServices;
using APIHexagonal.Domain.Interfaces.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace APIHexagonal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController: ControllerBase
    {
        protected readonly ICourseService _courseService;
        public CourseController(ICourseService service)
        {
            _courseService = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var courses = _courseService.GetAll();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var course = _courseService.GetById(id);

            if (course == null) 
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public IActionResult Create(CreateCourseDTO course)
        {
            _courseService.Create(course);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CreateCourseDTO course)
        {
            var result = _courseService.Update(id, course);

            if (!result) 
                return NotFound();

            return Ok("Course updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _courseService.Delete(id);

            if (!result) 
                return NotFound();

            return Ok("Course deleted successfully.");
        }
    }
}
