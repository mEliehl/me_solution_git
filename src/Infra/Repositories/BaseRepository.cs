using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace Infra.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Identity
    {
        protected DbContext Context
        {
            get
            {
                return new BaseContext();   
            }
        }

        public void Add(T entity)
        {
            Context.Add(entity);
        }

        public void AddRange(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IList<T> Get(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>()
                .Where(exp)
                .ToList();
        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IList<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IList<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
