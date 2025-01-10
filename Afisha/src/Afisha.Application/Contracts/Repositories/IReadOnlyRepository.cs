namespace Afisha.Application.Contracts.Repositories;

public interface IReadOnlyRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken = default) where TKey : struct;
    Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default);
}

