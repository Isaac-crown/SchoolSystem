using SchoolSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Interface
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync(bool trackChanges);
        void AddTeacherDetails(Teacher teacher);

        Task<Teacher> GetByTeacherNo(string teacherNo, bool trackChanges);


    }
}
