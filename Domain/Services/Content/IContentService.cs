using Domain.Abstractions;
using Domain.Entitiyes;

namespace Domain.Services.Content
{
    public interface IContentService: IDomainService
    {
        Task<Domain.Entitiyes.Content> CreateContentAsync(string Name,
            User Owner, 
            long TypeId,
            CancellationToken cancellationToken = default
        );
        Task<Domain.Entitiyes.Content> GetContentAsync(long Id,
            CancellationToken cancellationToken = default
        );

        Task<ICollection<Domain.Entitiyes.Content>> GetContentCollectionAsync(string stringSearch,
           CancellationToken cancellationToken = default);

    }
}
