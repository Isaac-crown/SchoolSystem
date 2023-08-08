using Microsoft.EntityFrameworkCore;
using SchoolSystem.Application.Interface;
using SchoolSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Repository
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
        public void AddStudentDetials(Student student) => Create(student);
       

       

        public async Task<Student> GetByStudentNumber(string studentNo, bool trackChanges)
        => await FindByCondition(x => x.StudentNumber.Equals(studentNo), trackChanges).SingleOrDefaultAsync();
    }
}
