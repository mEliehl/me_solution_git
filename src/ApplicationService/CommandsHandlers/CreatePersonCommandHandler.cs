using Domain.Commands;
using Domain.Entities;
using Domain.Repositories;
using Infra;
using Infra.Repositories.Factories;
using System.Threading.Tasks;

namespace ApplicationService.CommandsHandlers
{
    public class CreatePersonCommandHandler : ICommandHandler<CreatePersonCommand>
    {
        public async Task Handle(CreatePersonCommand command, UnitOfWork uow)
        {
           IPersonRepository personRepository = PersonRepositoryFactory.Create(uow.Context);
           var person = new Person(command.Name, command.Email);
           personRepository.Add(person);
        }
    }
}
