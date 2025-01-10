namespace Afisha.Application.Contracts.Repositories;

public interface IRepository<TEntity> : ISpecificationRepository<TEntity>, IReadOnlyRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TEntity>> AddRangeAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default);
    Task DeleteAsync<TKey>(TKey id, CancellationToken cancellationToken = default) where TKey : struct;
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteRangeAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task UpdateRangeAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default);
}