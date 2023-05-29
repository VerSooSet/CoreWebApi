using Command.Abstractions;
using Domain.Abstractions;
using Domain.Commands.Contexts;
using Domain.Criteria;
using Domain.Entitiyes;
using Domain.Exceptions;
using Queries.Abstractions;


namespace Domain.Services
{
    public abstract class ContentServiceBase
    {
        private readonly IAsyncCommandBuilder asyncCommandBuilder;
        private readonly IAsyncQueryBuilder asyncQueryBuilder;
        private readonly IDBServiceWithSearch service;

        protected ContentServiceBase(IAsyncCommandBuilder asyncCommandBuilder, IAsyncQueryBuilder asyncQueryBuilder, IDBServiceWithSearch service)
        {
            this.asyncCommandBuilder = asyncCommandBuilder ?? throw new ArgumentNullException(nameof(asyncCommandBuilder));
            this.asyncQueryBuilder = asyncQueryBuilder;
            this.service = service;
        }

        protected async Task<long> CreateContentAsync<TContent>(TContent content, CancellationToken cancellationToken = default) where TContent : Domain.Entitiyes.Content, new()
        {
            User? userAsOwner = await asyncQueryBuilder
                 .For<User>()
                 .WithAsync(new FindById(
                     content.Owner.Id), 
                     cancellationToken
                 ) ?? (User?) await service.GetAsync<User>(content.Owner.Id, cancellationToken); 
            
            if (userAsOwner == null) 
            {
                throw new UserNotFoundException();
            }

            await asyncCommandBuilder.ExecuteAsync(new CreateContentCommandContext(content), cancellationToken);

            return await service.AddAsync<TContent>(content, cancellationToken);
        }

        protected async Task<TContent> GetContentAsync<TContent>(long id, CancellationToken cancellationToken = default) where TContent : Domain.Entitiyes.Content, new()
        {
            TContent? content = await asyncQueryBuilder.For<TContent>().WithAsync(new FindById(id), cancellationToken);
            content = (TContent?) await service.GetAsync<TContent>(id, cancellationToken);
            return content?? throw new ContentNotFoundException();
        }

        protected async Task<ICollection<TContent>> GetContentCollectionAsync<TContent>(string searchString,CancellationToken cancellationToken = default) where TContent : Domain.Entitiyes.Content, new()
        {
            var dbCollection = asyncQueryBuilder.For<List<TContent>>().WithAsync<FindUsers>(new FindUsers(String.Empty), cancellationToken);
            var collectionAsync = await service.GetCollectionAsync<TContent>(searchString, cancellationToken);
            
            return collectionAsync.Select(x => (TContent)x).ToList();
        }
    }
}
