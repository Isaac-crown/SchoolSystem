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
    public class TeacherRepository : RepositoryBase<Teacher>, ITeacherRepository
    {

        public TeacherRepository(RepositoryContext repositoryContext) : base(repositoryContext) 
        {

        }
        public void AddTeacherDetails(Teacher teacher) => Create(teacher);
        

        public async Task<Teacher> GetByTeacherNo(string teacherNo, bool trackChanges)
        => await FindByCondition(x => x.TeacherNumber== teacherNo, trackChanges).SingleOrDefaultAsync();
    }
}
