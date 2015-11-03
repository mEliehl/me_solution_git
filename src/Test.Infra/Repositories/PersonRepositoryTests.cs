using Domain.Entities;
using Infra.Repositories;
using Xunit;

namespace Test.Infra.Repositories
{
    public class PersonRepositoryTests
    {
        [Fact]
        public void PassaTeste()
        {
            var actual = 1;
            var expected = 1;
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void AddTest()
        {
            var person = new Person("Marcos Eliehl dos Santos", "meliehl@outlook.com");
            var repositorio = new PersonRepository();
            repositorio.Add(person);
        }
    }
}
