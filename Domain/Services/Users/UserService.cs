using Command.Abstractions;
using Database.N;
using Domain.Abstractions;
using Domain.Entitiyes;
using Queries.Abstractions;

namespace Domain.Services.Users
{
    public class UserService : UserServiceBase,IUserService
    {
        public UserService(IAsyncCommandBuilder asyncCommandBuilder,IAsyncQueryBuilder asyncQueryBuilder, IDBServiceWithSearch service)
            : base(asyncCommandBuilder, asyncQueryBuilder, service)
        {
        }
        public async Task<User> CreateUserAsync(string Name, string Password, long CityId, CancellationToken cancellationToken)
        {
            var user = new User(Name,Password,CityId);
            user.Id = await CreateUserAsync<User>(user,cancellationToken);
            return user;
        }

        public async Task<User> FindUserAsync(string Name, CancellationToken cancellationToken = default, long Id = 0)
        {
            if (Id > 0)
                return await GetUserAsync(Id, cancellationToken);

            return await FindUserByLogin<User>(Name, cancellationToken);
        }

        public async Task<User> GetUserAsync(long Id, CancellationToken cancellationToken = default)
        {
            return await base.GetUserAsync<User>(Id, cancellationToken);
        }
        public async Task<ICollection<User>> GetUserCollectionAsync(string searchString, CancellationToken cancellationToken = default)
        {
            return await base.GetUserCollectionAsync<User>(searchString,cancellationToken);
        }

        public Task<User> UpdateUserAsync(long Id, string Name, long CityId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
