using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBaseRepository<T> where T : Identity
    {
        void Add(T entity);
        void AddRange(IList<T> entities);
        void Update(T entity);
        void UpdateRange(IList<T> entities);
        void Remove(Guid id);
        void Remove(T entity);
        void RemoveRange(IList<T> entities);
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        IList<T> Get(Expression<Func<T, bool>> exp);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
