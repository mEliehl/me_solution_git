using Infra.Contexts;
using Microsoft.Data.Entity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Infra
{
    public class UnitOfWork : IDisposable
    {
        public DbContext Context { get; private set; }

        internal UnitOfWork()
        {
            CreateContext();
        }

        public static UnitOfWork Create()
        {
            return new UnitOfWork();
        }

        private DbContext CreateContext()
        {
            Context = new BaseContext();

            return Context;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }
        }
    }
}
