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

        Task<User> FindUserAsync(string Name,
            CancellationToken cancellationToken = default,
            long Id = default
        );

        Task<User> GetUserAsync(long Id,
            CancellationToken cancellationToken = default
        );
        Task<ICollection<User>> GetUserCollectionAsync(string searchString,
            CancellationToken cancellationToken = default);
    }
}
