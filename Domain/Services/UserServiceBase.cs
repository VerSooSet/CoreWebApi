using global::Domain.Entitiyes;
using global::Domain.Commands;
using global::Command.Abstractions;
using Database.N;
using Domain.Exceptions;

namespace Domain.Services
{
    public abstract class UserServiceBase
    {
        private readonly IAsyncCommandBuilder asyncCommandBuilder;
        private readonly IDBService service;

        protected UserServiceBase(IAsyncCommandBuilder asyncCommandBuilder, IDBService service)
        {
            this.asyncCommandBuilder = asyncCommandBuilder ?? throw new ArgumentNullException(nameof(asyncCommandBuilder));
            this.service = service;
        }

        protected async Task CreateUserAsync<TUser>(TUser user, CancellationToken cancellationToken = default) where TUser : User, new()
        {
            await CheckUserLoginExist<TUser>(user.Login, cancellationToken);
            await asyncCommandBuilder.CreateAsync(user, cancellationToken);
            await service.AddAsync<TUser>(user, cancellationToken);
        }

        protected async Task CheckUserLoginExist<TUser>(string login, CancellationToken cancellationToken) where TUser : User, new()
        {
            var elements = await service.GetAsync<TUser>(cancellationToken);
            if (elements.Count > 0)
            {
                int existingCount = elements.Count(x => x.Login == login);
                if (existingCount != 0)
                    throw new UserLoginAlreadyExistsException();
            }
        }
    }
}
