using BusinessLogic.Entities;
using BusinessLogic.Models.Students;
using BusinessLogic.Repositories;
using DataAccess.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Services.Students
{
    public class StudentsService : IStudentRepository
    {
        private readonly DataDbContext _db;

        public StudentsService(DataDbContext context)
        {
            _db = context;
        }

        public async Task<bool> AddStudent(AddStudentModel student)
        {
            var studentEntity = student.Adapt<Student>();
            _db.Students.Add(studentEntity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteStudent(Guid id)
        {
            var studentEntity = await _db.Students.FindAsync(id);
            if (studentEntity == null)
            {
                return false; 
            }

            _db.Students.Remove(studentEntity);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<StudentModel?> GetStudentById(Guid id)
        {
            
            var studentEntity = await _db.Students.FindAsync(id);
            return studentEntity?.Adapt<StudentModel>();
        }

        public async Task<List<StudentModel>> GetStudents()
        {
           
            var studentEntities = await _db.Students.ToListAsync();
            return studentEntities.Adapt<List<StudentModel>>();
        }

        public async Task<bool> UpdateStudent(StudentModel student)
        {
            
            var studentEntity = await _db.Students.FindAsync(student.Id);
            if (studentEntity == null)
            {
                return false; 
            }
            
            student.Adapt(studentEntity);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
