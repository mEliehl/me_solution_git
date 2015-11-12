using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        protected abstract void ChangeEntity(Tentity entity);

        #region Tests
        [Fact]
        public void ShouldAddAndHasValidGuidTest()
        {
            var actual = CreateOneEntityAddSaveChanges();
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
            var actual = CreateOneEntityAddSaveChanges();
            Assert.True(repository.Any(a => a.Id == actual.Id));
        }

        [Fact]
        public async Task ShouldAddAndAnyAsyncReturnTrueTest()
        {
            var actual = CreateEntityToTest();
            repository.Add(actual);
            await repository.SaveChangesAsync();
            var expect = repository.AnyAsync(a => a.Id == actual.Id);
            Assert.True(await expect);
        }

        [Fact]
        public void ShouldAddAndGetReturnSameEntityTest()
        {
            var actual = CreateOneEntityAddSaveChanges();
            var expected = repository.Get(w => w.Id == actual.Id).FirstOrDefault();
            Assert.True(actual.Id == expected.Id);
        }

        [Fact]
        public async Task ShouldAddAndGetAsyncReturnSameEntityTest()
        {
            var actual = CreateOneEntityAddSaveChanges();
            var expected = await repository.GetAsync(w => w.Id == actual.Id);
            Assert.True(actual.Id == expected.FirstOrDefault().Id);
        }

        [Fact]
        public void ShouldAddAndGetByIdReturnSameEntityTest()
        {
            var actual = CreateOneEntityAddSaveChanges();
            var expected = repository.GetById(actual.Id);
            Assert.True(actual.Id == expected.Id);
        }

        [Fact]
        public async Task ShouldAddAndGetByIdAsyncReturnSameEntityTest()
        {
            var actual = CreateOneEntityAddSaveChanges();
            var expected = await repository.GetByIdAsync(actual.Id);
            Assert.True(actual.Id == expected.Id);
        }

        [Fact]
        public void ShouldAddAndRemoveByIdReturnNoEntityTest()
        {
            var actual = CreateOneEntityAddSaveChanges();
            repository.Remove(actual.Id);
            repository.SaveChanges();
            Assert.True(!repository.Any(a => a.Id == actual.Id));
        }

        [Fact]
        public void ShouldAddAndRemoveReturnNoEntityTest()
        {
            var actual = CreateOneEntityAddSaveChanges();
            repository.Remove(actual);
            repository.SaveChanges();
            Assert.True(!repository.Any(a => a.Id == actual.Id));
        }

        [Fact]
        public void ShouldAddAndRemoveRangeReturnNoEntityTest()
        {
            IEnumerable<Tentity> actual = new List<Tentity>() { CreateEntityToTest(), CreateEntityToTest() };
            repository.AddRange(actual);
            repository.SaveChanges();
            repository.RemoveRange(actual);
            repository.SaveChanges();
            Assert.True(!repository.Any(a => actual.All(a1 => a1.Id == a.Id)));
        }

        [Fact]
        public void ShouldAddAndUpdateChangePropertieTest()
        {
            var actual = CreateOneEntityAddSaveChanges();
            ChangeEntity(actual);
            repository.Update(actual);
            repository.SaveChanges();
            var expected = repository.GetById(actual.Id);
            Assert.Equal(expected.ToString(), actual.ToString());
        }

        [Fact]
        public void ShouldAddAndUpdateRangeChangePropertiesTest()
        {
            IEnumerable<Tentity> actual = new List<Tentity>() { CreateEntityToTest(), CreateEntityToTest() };
            repository.AddRange(actual);
            repository.SaveChanges();

            ChangeEntity(actual.FirstOrDefault());
            repository.UpdateRange(actual);
            repository.SaveChanges();

            var expected = repository.GetById(actual.FirstOrDefault().Id);
            Assert.Equal(expected.ToString(), actual.FirstOrDefault().ToString());
        }
        #endregion

        #region Helper Methods
        private Tentity CreateOneEntityAddSaveChanges()
        {
            var actual = CreateEntityToTest();
            repository.Add(actual);
            repository.SaveChanges();
            return actual;
        }
        #endregion
    }
}
