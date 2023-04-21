using Domain.Abstractions;
using Domain.Entitiyes;

namespace Domain.Services.Users
{
    public interface IUserService: IDomainService
    {
        Task<User> CreateUserAsync(string Name,
            string Password,
            long CityId,
            CancellationToken cancellationToken = default
        );

        Task<User> DeleteUserAsync(string Name,
            long Id,
            CancellationToken cancellationToken = default
        );

        Task<User> FindUserAsync(string Name,
            CancellationToken cancellationToken = default,
            long Id = default
        );

        Task<User> GetUserAsync(long Id,
            CancellationToken cancellationToken = default
        );

        Task<User> UpdateUserAsync(long Id, string Name, long CityId,
            CancellationToken cancellationToken = default
        );

        Task<ICollection<User>> GetUserCollectionAsync(
            CancellationToken cancellationToken = default);
    }
}
