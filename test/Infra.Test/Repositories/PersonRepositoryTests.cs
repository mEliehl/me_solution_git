using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Infra.Test.Repositories
{
    public class PersonRepositoryTests : BaseRepositoryTest<Person,PersonRepository>
    {
        readonly IPersonRepository personRepository;

        public PersonRepositoryTests()
            :base(new PersonRepository())
        {
            personRepository = new PersonRepository();
        }

        protected override Person CreateEntityToTest()
        {
            return new Person("Marcos Eliehl dos Santos", "meliehl@outlook.com");
        }

        [Fact]
        public async Task ShouldAddAndAnyAsyncReturnTrueTest()
        {
            var actual = CreateEntityToTest();
            personRepository.Add(actual);
            await personRepository.SaveChangesAsync();
            var expect = personRepository.AnyAsync(a => a.Id == actual.Id);
            Assert.True(await expect);
        }

        [Fact]
        public void ShouldAddAndGetReturnSameEntityTest()
        {
            var actual = CreateEntityToTest();
            personRepository.Add(actual);
            personRepository.SaveChanges();
            var expected = personRepository.Get(w => w.Id == actual.Id).FirstOrDefault();
            Assert.True(actual.Id == expected.Id);
        }

        [Fact]
        public async Task ShouldAddAndGetAsyncReturnSameEntityTest()
        {
            var actual = CreateEntityToTest();
            personRepository.Add(actual);
            personRepository.SaveChanges();
            var expected = await personRepository.GetAsync(w => w.Id == actual.Id);
            Assert.True(actual.Id == expected.FirstOrDefault().Id);
        }

        [Fact]
        public void ShouldAddAndGetByIdReturnSameEntityTest()
        {
            var actual = CreateEntityToTest();
            personRepository.Add(actual);
            personRepository.SaveChanges();
            var expected = personRepository.GetById(actual.Id);
            Assert.True(actual.Id == expected.Id);
        }

        [Fact]
        public async Task ShouldAddAndGetByIdAsyncReturnSameEntityTest()
        {
            var actual = CreateEntityToTest();
            personRepository.Add(actual);
            personRepository.SaveChanges();
            var expected = await personRepository.GetByIdAsync(actual.Id);
            Assert.True(actual.Id == expected.Id);
        }

        [Fact]
        public void ShouldAddAndRemoveByIdReturnNoEntityTest()
        {
            var actual = CreateEntityToTest();
            personRepository.Add(actual);
            personRepository.SaveChanges();
            personRepository.Remove(actual.Id);
            personRepository.SaveChanges();
            Assert.True(!personRepository.Any(a => a.Id == actual.Id));
        }

        [Fact]
        public void ShouldAddAndRemoveReturnNoEntityTest()
        {
            var actual = CreateEntityToTest();
            personRepository.Add(actual);
            personRepository.SaveChanges();
            personRepository.Remove(actual);
            personRepository.SaveChanges();
            Assert.True(!personRepository.Any(a => a.Id == actual.Id));
        }

        [Fact]
        public void ShouldAddAndRemoveRangeReturnNoEntityTest()
        {
            var actual = new List<Person>() { CreateEntityToTest(), CreateEntityToTest() };
            personRepository.AddRange(actual);
            personRepository.SaveChanges();
            personRepository.RemoveRange(actual);
            personRepository.SaveChanges();
            Assert.True(!personRepository.Any(a => actual.All(a1 => a1.Id == a.Id)));
        }

        [Fact]
        public void ShouldAddAndUpdateChangePropertieTest()
        {
            var actual = CreateEntityToTest();
            personRepository.Add(actual);
            personRepository.SaveChanges();
            actual.ChangeName("Marcolino");
            personRepository.Update(actual);
            personRepository.SaveChanges();
            Assert.True(personRepository.Any(a => a.Name == actual.Name));
        }

        [Fact]
        public void ShouldAddAndUpdateRangeChangePropertiesTest()
        {
            var actual = new List<Person>() { CreateEntityToTest(), CreateEntityToTest() };
            personRepository.AddRange(actual);
            personRepository.SaveChanges();

            actual.FirstOrDefault().ChangeName("Marcolino");
            personRepository.UpdateRange(actual);
            personRepository.SaveChanges();
            Assert.True(personRepository.Any(a => actual.Any(a1 => a1.Name == a.Name)));
        }
    }
}

