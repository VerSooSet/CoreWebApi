using Command.Abstractions;
using Database.N;
using Domain.Entitiyes;

namespace Domain.Services.Users
{
    public class UserService : UserServiceBase,IUserService
    {
        public UserService(IAsyncCommandBuilder asyncCommandBuilder,IDBService service)
            : base(asyncCommandBuilder,service)
        { }
        public async Task<User> CreateUserAsync(string Name, string Password, long CityId, CancellationToken cancellationToken)
        {
            var user = new User(Name,Password,CityId);
            await CreateUserAsync<User>(user,cancellationToken);
            return user;
        }
    }
}
