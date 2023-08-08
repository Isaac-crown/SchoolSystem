using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Service.Interface;
using SchoolSystem.Application.Shared;

namespace SchoolSystem.Presentation.Controllers
{
    [ApiController]
    [Route("api/school")]
    public class SchoolController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public SchoolController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("addteacherdetails")]
        [ProducesResponseType(typeof(GenericResponse<TeacherDto>), 200)]

        public async Task<IActionResult> AddTeacherDetails([FromBody] TeacherDto teacherDto)
        {
            var teacher = await _serviceManager.TeachersServices.CreateTeacher(teacherDto);

            return Ok(teacher);
        }

        [HttpPost("addstudentdetails")]
        [ProducesResponseType(typeof(GenericResponse<StudentDto>), 200)]

        public async Task<IActionResult> AddStudentDetails([FromBody] StudentDto studentDto)
        {
            var student = await _serviceManager.StudentServices.CreateStudent(studentDto);

            return Ok(student);
        }
    }
}
