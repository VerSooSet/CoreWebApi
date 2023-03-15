using Command.Abstractions;
using Database.N;
using Domain.Commands.Contexts;
using Domain.Entitiyes;
using System.Data.Common;

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

            #region FAKEd for deal with real db instead of Collections elements 
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

            await Task.CompletedTask;
        }
    }
}