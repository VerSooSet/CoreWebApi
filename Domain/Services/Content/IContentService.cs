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

        Task<Domain.Entitiyes.Content> DeleteContentAsync(long Id,
            CancellationToken cancellationToken = default
        );

        Task<Domain.Entitiyes.Content> FindContentAsync(string Name,
            CancellationToken cancellationToken = default
        );

        Task<Domain.Entitiyes.Content> GetContentAsync(long Id,
            CancellationToken cancellationToken = default
        );

        Task<Domain.Entitiyes.Content> UpdateContentAsync(long Id, 
            string Name, 
            long TypeId,
            CancellationToken cancellationToken = default
        );

    }
}
