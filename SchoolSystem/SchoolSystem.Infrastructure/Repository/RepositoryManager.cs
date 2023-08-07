using Microsoft.Extensions.Configuration;
using SchoolSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly IConfiguration _configuration;
        private readonly Lazy<IStudentRepository> _studentRepository;
        private readonly Lazy<ITeacherRepository> _teacherRepository;    

        public RepositoryManager(
            RepositoryContext repositoryContext, 
            IConfiguration configuration
         )
        {
            _repositoryContext = repositoryContext;
            _configuration = configuration;
        }
        public IStudentRepository StudentRepository => _studentRepository.Value;

        public ITeacherRepository TeacherRepository => _teacherRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
      
    }
}
