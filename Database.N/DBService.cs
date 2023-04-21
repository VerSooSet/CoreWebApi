using Domain.Abstractions;
using System.Collections;
using System.Collections.Concurrent;

namespace Database.N
{
    public class DBService : IDBService
    {
        private readonly int maxElementsValue; 
        private ConcurrentDictionary<long,IEntity> entityes { get; set; }
        
        [Obsolete]
        public DBService()
        {
            if (entityes == null)
            {
                entityes = new ConcurrentDictionary<long, IEntity>();
                maxElementsValue = 5;
            }
        }
        
        public async Task<Domain.Abstractions.IEntity> GetAsync<TEntity>(long id, CancellationToken cancellationToken = default) where TEntity: IEntity, new()
        {
            Domain.Abstractions.IEntity value = null;
            bool keyExists = entityes.TryGetValue(id, out value);
            if (!keyExists)
                await Task.FromException(new KeyNotFoundException(nameof(entityes)));
            if (value is not TEntity)
                await Task.FromException(new KeyNotFoundException(nameof(TEntity)));
            
            return await Task.FromResult(value);
        }

        public async Task<ICollection<TEntity>>GetCollectionAsync<TEntity>(CancellationToken cancellationToken = default) where TEntity : IEntity, new()
        {
            var collection = await Task.FromResult(
                ((entityes.Values) as IEnumerable)
                    .OfType<TEntity>()
                    .Cast<TEntity>()
                    .ToList()
            );
            return collection;
        }

        public async Task<long> AddAsync<IEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default)
        {
            if (entityes == null)
                throw new ArgumentNullException(nameof(entityes));

            int newElementId = entityes.Count + 1;
            if (newElementId < maxElementsValue)
            {
                entityes.TryAdd(newElementId, entity);
                return await Task.FromResult(newElementId);
            }
            await Task.FromException(new Exception(nameof(maxElementsValue)));
            return 0;
        }

        public async Task DeleteAsync<IEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default)
        {
            if (entityes == null)
                throw new ArgumentNullException(nameof(entityes));
            
            entityes.TryRemove(entity.Id, out entity);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync<TEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default) where TEntity: IEntity, new()
        {
            var element = await GetAsync<TEntity>(entity.Id, cancellationToken);
            if (element == null)
            {
                await Task.FromException(new ArgumentNullException());
                return;
            }
            entityes.AddOrUpdate(entity.Id,entity,(key,oldvalue) => oldvalue=entity);
            await Task.CompletedTask;
        }
        public async Task<IEntity> FindAsync<THasName>(string name, CancellationToken cancellationToken = default) where THasName: IHasName
        {
            IEntity value = null;

            var filtered = entityes
                .Where(x => x.Value.GetType() == typeof(THasName))
                .Select(x => x.Value)
                .Cast<THasName>()
                .ToList();
            if (filtered.Count() > 0 && filtered.Any(x => x.Name == name))
            {
                value = await Task.FromResult(
                    filtered.First(x => x.Name == name)) as IEntity;
            }
            return value;
        }
    }
}
