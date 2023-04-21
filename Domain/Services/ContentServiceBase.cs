using Command.Abstractions;
using Database.N;
using Domain.Commands.Contexts;
using Queries.Abstractions;

namespace Domain.Services
{
    public abstract class ContentServiceBase
    {
        private readonly IAsyncCommandBuilder asyncCommandBuilder;
        private readonly IAsyncQueryBuilder asyncQueryBuilder;
        private readonly IDBService service;

        protected ContentServiceBase(IAsyncCommandBuilder asyncCommandBuilder, IAsyncQueryBuilder asyncQueryBuilder, IDBService service)
        {
            this.asyncCommandBuilder = asyncCommandBuilder ?? throw new ArgumentNullException(nameof(asyncCommandBuilder));
            this.asyncQueryBuilder = asyncQueryBuilder;
            this.service = service;
        }

        protected async Task CreateContentAsync<TContent>(TContent content, CancellationToken cancellationToken = default) where TContent : Domain.Entitiyes.Content, new()
        {
           await asyncCommandBuilder.ExecuteAsync(new CreateContentCommandContext(content), cancellationToken);
            await service.AddAsync<TContent>(content, cancellationToken);
        }
    }
}
