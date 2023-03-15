using Command.Abstractions;
using Database.N;
using Domain.Commands;
using Domain.Entitiyes;

namespace Domain.Services
{
    public abstract class ContentServiceBase
    {
        private readonly IAsyncCommandBuilder asyncCommandBuilder;
        private readonly IDBService service;

        protected ContentServiceBase(IAsyncCommandBuilder asyncCommandBuilder, IDBService service)
        {
            this.asyncCommandBuilder = asyncCommandBuilder ?? throw new ArgumentNullException(nameof(asyncCommandBuilder));
            this.service = service;
        }

        protected async Task CreateContentAsync<TContent>(TContent content, CancellationToken cancellationToken = default) where TContent : Content, new()
        {
           
            await asyncCommandBuilder.CreateAsync(content, cancellationToken);
            await service.AddAsync<TContent>(content, cancellationToken);
        }
    }
}
