using Domain.Entities;
using Domain.Repositories;
using Infra.Contexts;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;

namespace Infra.Repositories
{
    internal abstract class BaseRepository<T> : IBaseRepository<T> where T : Identity
    {
        protected readonly DbContext Context;

        public BaseRepository()
        {
            Context = new BaseContext();
        }

        public void Add(T entity)
        {
            Context.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.AddRange(entities);
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Any(exp);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().AnyAsync(exp);
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>()
                .Where(exp)
                .ToList();
        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>()
                .Where(exp)
                .ToListAsync();
        }

        public T GetById(Guid id)
        {
            return Context.Set<T>().FirstOrDefault(f => f.Id == id);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Context.Set<T>().FirstOrDefaultAsync(f => f.Id == id);
        }

        public void Remove(T entity)
        {
            Context.Remove(entity);
        }

        public void Remove(Guid id)
        {
            var entity = GetById(id);
            if (entity != null)
                Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Context.UpdateRange(entities);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
