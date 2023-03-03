using Domain.Abstractions;

namespace Database.N
{
    public interface IDBService
    {
        Task<IEntity> GetAsync<IEntity>(long id, CancellationToken cancellationToken = default);// where TEntity: IEntity,new();
        Task<ICollection<IEntity>> GetAsync<IEntity>(CancellationToken cancellationToken = default);// where TEntity : IEntity, new();
        Task<long> AddAsync<IEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default);// where TEntity: IEntity,new(); 
        Task UpdateAsync(IEntity entity, CancellationToken cancellationToken = default);
        //Task<IEntity> FindAsync<IEntity>(string Name, CancellationToken cancellationToken = default);
    }
}
