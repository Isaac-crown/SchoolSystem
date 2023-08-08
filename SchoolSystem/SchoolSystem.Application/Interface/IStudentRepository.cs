

using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Interface
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudents(bool trackChanges);

        Task<Student> GetByStudentNumber(string studentNo, bool trackChanges);
        void AddStudentDetials(Student student);


    }
}
