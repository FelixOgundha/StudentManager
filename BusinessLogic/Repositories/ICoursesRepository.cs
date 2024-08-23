using BusinessLogic.Models.Courses;

namespace BusinessLogic.Repositories
{
    public interface ICoursesRepository
    {
       
        Task AddCourse(AddCourseModel course);

        
        Task<List<CourseModel>> GetCourses();

        
        Task<CourseModel?> GetCourseById(Guid id);

       
        Task UpdateCourse(CourseModel course);

       
        Task DeleteCourse(Guid id);
    }
}
