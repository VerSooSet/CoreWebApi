using Domain.Abstractions;

namespace Database.N
{
    public interface IDBService
    {
        Task<Domain.Abstractions.IEntity> GetAsync<TEntity>(long id, CancellationToken cancellationToken = default) where TEntity : IEntity, new();
        Task<ICollection<TEntity>> GetCollectionAsync<TEntity>(CancellationToken cancellationToken = default) where TEntity : IEntity, new();
        Task<long> AddAsync<IEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync<TEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default) where TEntity : IEntity, new();
        Task DeleteAsync<IEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default);
        Task<IEntity> FindAsync<THasName>(string name, CancellationToken cancellationToken = default) where THasName : IHasName;
    }
}
