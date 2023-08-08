using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Application.Service.Interface
{
    public interface ITeacherServices
    {
        Task<GenericResponse<TeacherDto>> CreateTeacher(TeacherDto dto);
    }
}
