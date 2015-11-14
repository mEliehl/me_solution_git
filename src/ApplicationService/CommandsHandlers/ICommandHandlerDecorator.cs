using Domain.Commands;
using System.Threading.Tasks;

namespace ApplicationService.CommandsHandlers
{
    public interface ICommandHandlerDecorator<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}

