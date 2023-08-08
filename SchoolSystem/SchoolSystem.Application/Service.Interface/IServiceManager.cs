using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Service.Interface
{
    public interface IServiceManager
    {
        IStudentServices StudentServices { get; }

        ITeacherServices    TeachersServices { get; }
    }
}
