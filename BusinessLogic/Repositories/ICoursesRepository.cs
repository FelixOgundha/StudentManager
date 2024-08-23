using BusinessLogic.Models.Courses;

namespace BusinessLogic.Repositories
{
    public interface ICoursesRepository
    {
       
        Task<bool> AddCourse(AddCourseModel course);

        
        Task<List<CourseModel>> GetCourses();

        
        Task<CourseModel?> GetCourseById(Guid id);

       
        Task<bool> UpdateCourse(CourseModel course);

       
        Task<bool> DeleteCourse(Guid id);
    }
}
