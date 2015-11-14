using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;
using Infra.Repositories.Factories;

namespace Infra.Test.Repositories
{
    public class PersonRepositoryTests : BaseRepositoryTest<Person,IPersonRepository>
    {
        public PersonRepositoryTests()
            :base(PersonRepositoryFactory.Create(UnitOfWork.Create().Context))
        {
            
        }

        protected override Person CreateEntityToTest()
        {
            return new Person("Marcos Eliehl dos Santos", "meliehl@outlook.com");
        }

        protected override void ChangeEntity(Person entity)
        {
            entity.ChangeName("Marcolino");
        }
    }
}

