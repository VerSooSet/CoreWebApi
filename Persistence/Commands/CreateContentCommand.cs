using Command.Abstractions;
using Database.N;
using Domain.Commands.Contexts;

namespace Persistence.Commands
{
    public class CreateContentCommand : IAsyncCommand<CreateContentCommandContext>
    {
        private readonly IDbCurrentTransactionProvider provider;

        public CreateContentCommand(IDbCurrentTransactionProvider provider)
        {
            this.provider = provider;
        }
        public async Task ExecuteAsync(CreateContentCommandContext context, 
            CancellationToken cancellationToken = default)
        {
            Console.WriteLine(
                String.Format(
                    "[{0}] Sended command create one Content",
                    DateTime.Now.ToShortTimeString()
                )
            );
            await Task.CompletedTask;
        }
    }
}
