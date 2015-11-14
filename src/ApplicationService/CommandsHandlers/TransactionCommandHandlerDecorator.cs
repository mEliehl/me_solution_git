using Domain.Commands;
using Infra;
using System.Threading.Tasks;

namespace ApplicationService.CommandsHandlers
{
    public class TransactionCommandHandlerDecorator<TCommand> : ICommandHandlerDecorator<TCommand> 
        where TCommand : ICommand
    {
        private readonly ICommandHandler<TCommand> decorated;

        public TransactionCommandHandlerDecorator(ICommandHandler<TCommand> decorated)
        {
            this.decorated = decorated;
        }

        public async Task Handle(TCommand command)
        {
            using (var uow = UnitOfWork.Create())
            {
                await decorated.Handle(command,uow);

                await uow.SaveChangesAsync();
            }
        }
    }
}
