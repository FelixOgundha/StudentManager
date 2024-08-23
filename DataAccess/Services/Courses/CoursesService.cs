using BusinessLogic.Entities;
using BusinessLogic.Models.Courses;
using BusinessLogic.Repositories;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;


using Mapster;
namespace DataAccess.Services.Courses
{
    public class CoursesService : ICoursesRepository
    {
        private readonly DataDbContext _db;

        public CoursesService(DataDbContext database)
        {
            _db = database;
        }
        public async Task AddCourse(AddCourseModel course)
        {
            var courseEntity = course.Adapt<Course>(); 
            _db.Courses.Add(courseEntity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteCourse(Guid id)
        {
            var courseEntity = await _db.Courses.FindAsync(id);
            if (courseEntity == null) return;

            _db.Courses.Remove(courseEntity);
            await _db.SaveChangesAsync();
        }

        public async Task<CourseModel?> GetCourseById(Guid id)
        {
            var courseEntity = await _db.Courses.FindAsync(id);
            return courseEntity?.Adapt<CourseModel>();
        }

        public async Task<List<CourseModel>> GetCourses()
        {
            var courseEntities = await _db.Courses.ToListAsync();
            return courseEntities.Adapt<List<CourseModel>>();
        }

        public async Task UpdateCourse(CourseModel course)
        {
            var courseEntity = await _db.Courses.FindAsync(course.Id);
            if (courseEntity == null) return;

            course.Adapt(courseEntity); 
            await _db.SaveChangesAsync();
        }
    }
}
