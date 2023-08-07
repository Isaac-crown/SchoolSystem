using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Interface
{
    public interface IRepositoryManager
    {
        IStudentRepository StudentRepository { get; }

        ITeacherRepository TeacherRepository { get; }


        Task SaveAsync();
    }
}
