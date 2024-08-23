using BusinessLogic.Models.Students;

namespace BusinessLogic.Repositories
{
    public interface IStudentRepository
    {
        
        Task<bool> AddStudent(AddStudentModel student);

        Task<List<StudentModel>> GetStudents();

        Task<StudentModel?> GetStudentById(Guid id);

        Task<bool> UpdateStudent(StudentModel student);

        Task<bool> DeleteStudent(Guid id);
    }
}
