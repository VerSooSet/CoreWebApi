using Database.N;
using Domain.Commands.Contexts;
using Command.Abstractions;


namespace Persistence.Commands
{
    public class DeleteUserCommand: IAsyncCommand<DeleteUserCommandContext>
    {
        private readonly IDbCurrentTransactionProvider dbProvider;

        public DeleteUserCommand(IDbCurrentTransactionProvider provider)
        {
            dbProvider = provider;
        }

        public async Task ExecuteAsync(
            DeleteUserCommandContext commandContext,
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine("Sended command delete User by Id");
            await Task.CompletedTask;
        }
    }
}
