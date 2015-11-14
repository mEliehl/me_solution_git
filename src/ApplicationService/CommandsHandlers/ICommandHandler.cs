using Domain.Commands;
using Infra;
using System.Threading.Tasks;

namespace ApplicationService.CommandsHandlers
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command,UnitOfWork uow);
    }
}
