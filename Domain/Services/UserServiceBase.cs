using global::Domain.Entitiyes;
using global::Command.Abstractions;
using Domain.Exceptions;
using Domain.Commands.Contexts;
using Queries.Abstractions;
using Domain.Criteria;
using Domain.Abstractions;

namespace Domain.Services
{
    
    public abstract class UserServiceBase
    {
        private readonly IAsyncCommandBuilder commandBuilder;
        private readonly IAsyncQueryBuilder queryBuilder;
        private readonly IDBServiceWithSearch service;

        protected UserServiceBase(IAsyncCommandBuilder commandBuilder, IAsyncQueryBuilder queryBuilder, IDBServiceWithSearch service)
        {
            this.commandBuilder = commandBuilder ?? throw new ArgumentNullException(nameof(commandBuilder));
            this.queryBuilder = queryBuilder;
            this.service = service;
        }

        protected async Task<long> CreateUserAsync<TUser>(TUser user, CancellationToken cancellationToken = default) where TUser : User, new()
        {
            await CheckUserLoginExist<TUser>(user.Login, cancellationToken);
            await commandBuilder.ExecuteAsync(new CreateUserCommandContext(user), cancellationToken);
            return await service.AddAsync<TUser>(user, cancellationToken);
        }

        protected async Task<TUser> GetUserAsync<TUser>(long id, CancellationToken cancellationToken = default) where TUser : User, new()
        {
            TUser? user = await queryBuilder.For<TUser>().WithAsync(new FindById(id),cancellationToken);
            user = (TUser?)await service.GetAsync<TUser>(id, cancellationToken);
            return user ?? throw new UserNotFoundException();
        }

        protected async Task<ICollection<TUser>> GetUserCollectionAsync<TUser>(string searchString, CancellationToken cancellationToken = default) where TUser : User, new()
        {
            var dbCollection = await queryBuilder.For<List<TUser>>().WithAsync<FindUsers>(new FindUsers(searchString), cancellationToken);

            var collection = await service.GetCollectionAsync<TUser>(searchString,cancellationToken);
            var result = collection.Select(x => (TUser)x).ToList();
            return dbCollection ?? result;
        }

        protected async Task CheckUserLoginExist<TUser>(string login, CancellationToken cancellationToken) where TUser : User, new()
        {
            #region on Database data
            int existingCount = await queryBuilder
                .For<int>()
                .WithAsync(new FindUsersCountByLogin(login), cancellationToken);

            if (existingCount > 0)
                throw new UserLoginAlreadyExistsException();
            #endregion

            #region on App collection data
            var user = await service.FindAsync<TUser>(login, cancellationToken);
            if (user != null)
                throw new UserLoginAlreadyExistsException();
            #endregion
        }

        protected async Task<TUser> FindUserByLogin<TUser>(string login, CancellationToken cancellationToken) where TUser : User, new()
        {
            TUser user = await queryBuilder
                .For<TUser>()
                .WithAsync(new FindUserByLogin(login), cancellationToken);
            
            return (TUser)await service.FindAsync<TUser>(login, cancellationToken);
            
        }
    }
}
