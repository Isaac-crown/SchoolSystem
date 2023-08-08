

using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Interface
{
    public interface IStudentRepository
    {

        Task<Student> GetByStudentNumber(string studentNo, bool trackChanges);
        void AddStudentDetials(Student student);


    }
}
