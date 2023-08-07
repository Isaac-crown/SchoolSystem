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
        void AddTeacherDetails(Student student);
    }
}
