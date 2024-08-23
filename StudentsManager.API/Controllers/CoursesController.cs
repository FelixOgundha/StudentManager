using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Repositories;
using BusinessLogic.Models.Courses; // Assume the DTOs are in this namespace
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StudentsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _coursesRepository;

        public CoursesController(ICoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

       
        [HttpGet]
        public async Task<ActionResult<List<CourseModel>>> GetCourses()
        {
            var courses = await _coursesRepository.GetCourses();
            return Ok(courses);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourseById(Guid id)
        {
            var course = await _coursesRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<ActionResult> AddCourse([FromBody] AddCourseModel addCourseModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _coursesRepository.AddCourse(addCourseModel);

            return CreatedAtAction(nameof(GetCourseById), new { id = addCourseModel.Id }, addCourseModel);
        }

       
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCourse(Guid id, [FromBody] CourseModel courseModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != courseModel.Id)
            {
                return BadRequest("Course ID mismatch");
            }

            await _coursesRepository.UpdateCourse(courseModel);

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(Guid id)
        {
            var existingCourse = await _coursesRepository.GetCourseById(id);
            if (existingCourse == null)
            {
                return NotFound();
            }

            await _coursesRepository.DeleteCourse(id);

            return NoContent();
        }
    }
}
