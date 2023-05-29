﻿using System.Diagnostics.CodeAnalysis;

namespace Domain.Abstractions
{
    public interface IDBServiceWithSearch
    {
        [return: MaybeNull]
        Task<Domain.Abstractions.IEntity?> GetAsync<TEntity>(long id, CancellationToken cancellationToken = default) where TEntity : IEntity, new();
        Task<ICollection<TEntity>> GetCollectionAsync<TEntity>(string? searchString, CancellationToken cancellationToken = default) where TEntity : IEntity,IHasName, new();
        Task<long> AddAsync<IEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync<TEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default) where TEntity : IEntity, new();
        Task DeleteAsync<IEntity>(Domain.Abstractions.IEntity entity, CancellationToken cancellationToken = default);
        [return: MaybeNull]
        Task<IEntity?> FindAsync<THasName>(string name, CancellationToken cancellationToken = default) where THasName : IHasName;
    }
}
