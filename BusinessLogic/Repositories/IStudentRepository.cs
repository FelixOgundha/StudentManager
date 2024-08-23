using BusinessLogic.Models.Students;

namespace BusinessLogic.Repositories
{
    public interface IStudentRepository
    {
        
        Task AddStudent(AddStudentModel student);

        Task<List<StudentModel>> GetStudents();

        Task<StudentModel?> GetStudentById(Guid id);

        Task UpdateStudent(StudentModel student);

        Task DeleteStudent(Guid id);
    }
}
