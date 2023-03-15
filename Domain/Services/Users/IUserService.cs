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

    }
}
