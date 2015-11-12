using Domain.Entities;
using Domain.Repositories;
using Infra.Repositories;

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

        protected override void ChangeEntity(Person entity)
        {
            entity.ChangeName("Marcolino");
        }
    }
}

