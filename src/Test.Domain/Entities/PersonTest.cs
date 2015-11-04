using Domain.Entities;
using Xunit;

namespace Test.Domain.Entities
{
    public class PersonTest
    {
        private Person CreateTestObject()
        {
            return new Person("Marcos Eliehl dos Santos", "meliehl@outlook.com");
        }

        [Fact]
        public void ShouldCreateValidObject()
        {
            var actual = CreateTestObject();
            Assert.True(!string.IsNullOrWhiteSpace(actual.Name));
            Assert.True(!string.IsNullOrWhiteSpace(actual.Email));
        }

        [Fact]
        public void ShouldCreateValidObjectAndChangeName()
        {
            var actual = CreateTestObject();
            var expected = "Marcolino";
            actual.ChangeName("Marcolino");
            Assert.Equal(expected,actual.Name);
            
        }

    }
}
