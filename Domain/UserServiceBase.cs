using Domain.Entitiyes;
using Transcactions;

namespace Domain
{
    public abstract class UserServiceBase
    {
        private readonly IAsyncCommandBuilder asyncCommandBuilder;
        protected UserServiceBase(IAsyncCommandBuilder asyncCommandBuilder)
        {
            this.asyncCommandBuilder = asyncCommandBuilder;
        }

        private async Task CreateUserAsync<TUser>(TUser user, CancellationToken cancellationToken) where TUser : User, new()
        { 
            
        }

        private async Task CheckUserNameExist<TUser>(string Name, CancellationToken cancellationToken)
        {
            
        }
    }
}
