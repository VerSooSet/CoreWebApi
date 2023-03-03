using Domain.Abstractions;
using System.Collections.Concurrent;

namespace Database.N
{
    public class DBService : IDBService
    {
        private readonly int maxElementsValue;

        //private IEntity[] entityes { get; }
        private ConcurrentDictionary<long,IEntity> entityes { get; }
        public DBService(ConcurrentDictionary<long,IEntity> entityes, int maxElementsValue) 
        {
            this.entityes = entityes;
            this.maxElementsValue = maxElementsValue;
        }
        public async Task<IEntity> GetAsync<IEntity>(long id, CancellationToken cancellationToken = default)
        {
            //return (IEntity) await Task.FromResult(entityes.Single(x => x.Id == id));
            Domain.Abstractions.IEntity value;
            bool keyExists = entityes.TryGetValue(id, out value);
            if (!keyExists)
                await Task.FromException(new KeyNotFoundException(nameof(entityes)));
            return (IEntity)await Task.FromResult(value);
        }

        public async Task<ICollection<IEntity>>GetAsync<IEntity>(CancellationToken cancellationToken = default)
        {
            //return await Task.FromResult(Array.FindAll(entityes, x => x != null).ToList()) as ICollection<IEntity>;
            return await Task.FromResult(entityes.Values) as ICollection<IEntity>;
        }

        public async Task<long> AddAsync<IEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default)
        {
            /*if (entityes.Any(x => x != null))
            {
                int pos = Array.FindIndex(entityes, x => x == null);
                entityes[pos] = (Domain.Abstractions.IEntity)entity;
            }*/
            int newElementId = entityes.Count;
            while (newElementId< maxElementsValue)//(entityes.Count>0)
            {
                entityes.TryAdd(newElementId, entity);
                return await Task.FromResult(newElementId);
            }
            await Task.FromException(new Exception(nameof(maxElementsValue)));
            return 0;
        }

        public async Task UpdateAsync(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default)
        {
            var element = await GetAsync<IEntity>(entity.Id);
            if (element == null)
            {
                await Task.FromException(new ArgumentNullException());
                return;
            }
            /*int pos = Array.FindIndex(entityes, x => x.Id == entity.Id);
            entityes[pos] = entity;*/
            entityes.AddOrUpdate(entity.Id,entity,(key,oldvalue) => oldvalue=entity);
            await Task.CompletedTask;
        }


        /*public async Task<IEntity> FindAsync<IEntity>(Type userType, string Name, CancellationToken cancellationToken = default)
        {
            if (nameof(userType) == "User")
            {
                var list = entityes.Cast<User>();
                if (entityes.Any(x => x.Value. == Name))
                {
                    return (IEntity)await Task.FromResult(entityes.Single(x => x.Name == id));
                }
            }
        }*/
    }
}
