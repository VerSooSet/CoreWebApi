using Domain.Abstractions;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Database.N
{
    public class DBService : IDBServiceWithSearch
    {
        private readonly int maxElementsValue; 
        private ConcurrentDictionary<long,IEntity> entityesDictionary { get; set; }
        
        [Obsolete]
        public DBService()
        {
            if (entityesDictionary == null)
            {
                entityesDictionary = new ConcurrentDictionary<long, IEntity>();
                maxElementsValue = 5;
            }
        }

        [return: MaybeNull]
        public async Task<Domain.Abstractions.IEntity?> GetAsync<TEntity>(long id, CancellationToken cancellationToken = default) where TEntity: IEntity, new()
        {
            var correctTypeEntityes = entityesDictionary.Values.OfType<TEntity>();
            
            if (correctTypeEntityes.Count() == 0)
               return await Task.FromResult<Domain.Abstractions.IEntity?>(null);

            if (
                (from element in correctTypeEntityes
                 where element.Id == id
                 select element)
                 .Any()
                 )
            {}
            else {
                Console.WriteLine(String.Format("[{0}] {1} not found by Id",
                       DateTime.Now.ToShortTimeString(),
                       typeof(TEntity).Name
                 ));
            }
            var value = correctTypeEntityes.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult<Domain.Abstractions.IEntity?>(value);
        }

        public async Task<ICollection<TEntity>>GetCollectionAsync<TEntity>(string? searchString, CancellationToken cancellationToken = default) where TEntity : IEntity,IHasName, new()
        {
            var correctTypeEntityes = await Task.FromResult(
                ((entityesDictionary.Values) as IEnumerable)
                    .OfType<TEntity>()
                    .ToList()
            );
            if (searchString != null
                && typeof(TEntity).GetInterfaces().Contains(typeof(IHasName)))
            {
                var filtered = correctTypeEntityes.Where(x => 
                                                    x.Name == searchString)
                                            .ToList();
                return filtered;
            }
            return correctTypeEntityes;
        }

        public async Task<long> AddAsync<IEntity>([NotNull]Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default)
        {
            if (entityesDictionary == null)
                throw new NullReferenceException(nameof(entityesDictionary));

            int newElementId = entityesDictionary.Count + 1;
            if (newElementId < maxElementsValue)
            {
                entityesDictionary.TryAdd(newElementId, entity);
                return await Task.FromResult(newElementId);
            }
            await Task.FromException(new ArgumentOutOfRangeException(nameof(maxElementsValue)));
            return 0;
        }

        public async Task DeleteAsync<IEntity>([NotNull] Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default)
        {
            if (entityesDictionary == null)
                throw new NullReferenceException(nameof(entityesDictionary));
            Domain.Abstractions.IEntity? tempValue = null;

            entityesDictionary.TryRemove(entity.Id,out tempValue);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync<TEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default) where TEntity: IEntity, new()
        {
            IEntity? element = await GetAsync<TEntity>(entity.Id, cancellationToken)!;
            if (element == null)
            {
                Console.WriteLine(String.Format("[{0}] {1} not found by Id = {2}",
                      DateTime.Now.ToShortTimeString(),
                      typeof(TEntity).Name,
                      entity.Id
                ));
                await Task.FromException(new NullReferenceException(nameof(element)));
                return;
            }
            entityesDictionary.AddOrUpdate(entity.Id,entity,(key,oldvalue) => oldvalue=entity);
            await Task.CompletedTask;
        }
        [return: MaybeNull]
        public async Task<IEntity?> FindAsync<THasName>(string name, CancellationToken cancellationToken = default) where THasName: IHasName
        {
            IEntity? value = null;

            var filtered = entityesDictionary
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
