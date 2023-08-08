using SchoolSystem.Application.Interface;
using SchoolSystem.Application.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly Lazy<IStudentServices> _studentServices;
        private readonly Lazy<ITeacherServices> _teacherServices;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
            _studentServices = new Lazy<IStudentServices>(() => new StudentServices(repositoryManager));
            _teacherServices = new Lazy<ITeacherServices>(() => new TeacherServices(repositoryManager));
        }
        public IStudentServices StudentServices => _studentServices.Value;

        public ITeacherServices TeachersServices => _teacherServices.Value;
    }
}
