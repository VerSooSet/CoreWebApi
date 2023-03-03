using global::Domain.Abstractions;
using global::Command.Abstractions;
using Domain.Entitiyes;

namespace Domain.Commands
{
    public class CreateEntityCommandContext<TEntity> : ICommandContext
        where TEntity : class, IEntity, new()
    {
        public TEntity SomeEntity { get; }
        
        public CreateEntityCommandContext(TEntity entity)
        {
            SomeEntity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
    }

    public static class CreateEntityCommandContextExtensions
    {
        public static Task CreateAsync<TEntity>(
            this IAsyncCommandBuilder commandBuilder,
            TEntity Entity,
            CancellationToken cancellationToken = default) where TEntity: class, IEntity, new()
        {
            return commandBuilder.ExecuteAsync(
                new CreateEntityCommandContext<TEntity>(Entity),
                cancellationToken);
        }
    }
}
