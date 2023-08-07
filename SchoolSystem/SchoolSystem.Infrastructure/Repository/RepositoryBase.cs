using Microsoft.EntityFrameworkCore;
using SchoolSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext) => _repositoryContext = repositoryContext;
        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? _repositoryContext.Set<T>().AsNoTracking() : _repositoryContext.Set<T>();


        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? _repositoryContext.Set<T>().Where(expression).AsNoTracking() : _repositoryContext.Set<T>().Where(expression);

        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);
    }
}
