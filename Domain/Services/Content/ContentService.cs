using Command.Abstractions;
using Domain.Abstractions;
using Domain.Entitiyes;
using Domain.Exceptions;
using Queries.Abstractions;

namespace Domain.Services.Content
{
    public class ContentService : ContentServiceBase,IContentService
    {
        public ContentService(IAsyncCommandBuilder asyncCommandBuilder, IAsyncQueryBuilder asyncQueryBuilder, IDBServiceWithSearch service) : 
            base(asyncCommandBuilder, asyncQueryBuilder, service)
        {
        }

        public async Task<Entitiyes.Content> CreateContentAsync(string Name, User Owner, long TypeId, CancellationToken cancellationToken = default)
        {
            if (Owner == null)
            {
                throw new UserNotFoundException();
            }

            var content = new Domain.Entitiyes.Content(
                name: Name, 
                owner: Owner,
                typeId: TypeId);
            content.Id = await CreateContentAsync<Domain.Entitiyes.Content>(content, cancellationToken);
            return content;
        }

        public async Task<Entitiyes.Content> GetContentAsync(long Id, CancellationToken cancellationToken = default)
        {
            return await base.GetContentAsync<Entitiyes.Content>(Id, cancellationToken); ;
        }

        public async Task<ICollection<Entitiyes.Content>> GetContentCollectionAsync(string searchString, CancellationToken cancellationToken = default)
        {
            return await base.GetContentCollectionAsync<Entitiyes.Content>(searchString,cancellationToken) ?? throw new ContentNotFoundException();
        }

    }
}
