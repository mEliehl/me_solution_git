using Domain.Entities;
using Infra.Configs;
using Microsoft.Data.Entity;

namespace Infra.Contexts
{
    public class BaseContext : DbContext
    {
        public new DbSet<T> Set<T>() where T : Identity
        {
            return base.Set<T>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Person>(PersonConfig.Config());
        }
    }
}
