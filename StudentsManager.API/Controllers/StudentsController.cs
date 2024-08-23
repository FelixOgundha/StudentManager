using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Repositories;
using BusinessLogic.Models.Students;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StudentsManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
    
        [HttpGet]
        public async Task<ActionResult<List<StudentModel>>> GetStudents()
        {
            var students = await _studentRepository.GetStudents();
            return Ok(students);
        }
   
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentById(Guid id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] AddStudentModel addStudentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _studentRepository.AddStudent(addStudentModel);

            if (result is false) return BadRequest("Invalid Request, studet already exists");

            return Ok("Student Addedd");
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent([FromBody] StudentModel studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _studentRepository.UpdateStudent(studentModel);

            return Ok("Student Updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(Guid id)
        {
            var existingStudent = await _studentRepository.GetStudentById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            await _studentRepository.DeleteStudent(id);

            return Ok("Student Deleted");
        }
    }
}
