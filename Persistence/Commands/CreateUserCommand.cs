using Command.Abstractions;
using Database.N;
using Domain.Commands.Contexts;


namespace Persistence.Commands
{
    public class CreateUserCommand : IAsyncCommand<CreateUserCommandContext>
    {
        private readonly IDbCurrentTransactionProvider dbProvider;
        
        public CreateUserCommand(IDbCurrentTransactionProvider provider)
        {
            dbProvider = provider;
        }    
                
        public async Task ExecuteAsync(
            CreateUserCommandContext commandContext, 
            CancellationToken cancellationToken = default)
        {

            #region example of work with real db instead of collection 
            /*
                DbTransaction transaction = await dbProvider.GetCurrentTransactionAsync(cancellationToken);
                DbConnection connection = transaction.Connection;

                await using CollectionDBCommand command = (CollectionDBCommand)connection.CreateCommand();
                command.Parameters.AddWithValue("Login", commandContext.User.Login);
                command.Parameters.AddWithValue("CityId", commandContext.User.City);
                long result = (long)await command.ExecuteScalarAsync();
                commandContext.User.Id = result;
            */
            #endregion
            Console.WriteLine("Sended command create one User");
            await Task.CompletedTask;
        }
    }
}