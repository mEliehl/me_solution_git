using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Infra.Test.Repositories
{
    public abstract class BaseRepositoryTest<Tentity,TRepository>
        where Tentity : Identity 
        where TRepository : IBaseRepository<Tentity>
    {
        readonly IBaseRepository<Tentity> repository;

        public BaseRepositoryTest(IBaseRepository<Tentity> repository)
        {
            this.repository = repository;
        }

        protected abstract Tentity CreateEntityToTest();

        [Fact]
        public void ShouldAddAndHasValidGuidTest()
        {
            var actual = CreateEntityToTest();
            repository.Add(actual);
            repository.SaveChanges();
            Assert.True(actual.Id != Guid.Empty);
        }

        [Fact]
        public void ShouldAddRangeAndHasValidsGuidsTest()
        {
            IEnumerable<Tentity> actual = new List<Tentity>() { CreateEntityToTest(), CreateEntityToTest() };
            repository.AddRange(actual);
            repository.SaveChanges();
            Assert.True(actual.All(a => a.Id != Guid.Empty));
        }

        [Fact]
        public void ShouldAddAndAnyReturnTrueTest()
        {
            var actual = CreateEntityToTest();
            repository.Add(actual);
            repository.SaveChanges();
            Assert.True(repository.Any(a => a.Id == actual.Id));
        }
    }
}
