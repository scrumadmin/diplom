using Afisha.Application.Contracts.Repositories;

namespace Afisha.Infrastructure.Data.Repositories;

public class RepositoryBase<TEntity> : ReadOnlyRepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class
{
    public RepositoryBase(AfishaDbContext context) : base(context)
    {
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public virtual async Task<IReadOnlyCollection<TEntity>> AddRangeAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().AddRange(entities);

        await _context.SaveChangesAsync(cancellationToken);

        return entities;
    }

    public virtual async Task DeleteAsync<TKey>(TKey id, CancellationToken cancellationToken = default) where TKey : struct
    {
        var entity = await GetByIdAsync(id, cancellationToken);

        await DeleteAsync(entity, cancellationToken);
    }

    public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteRangeAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().RemoveRange(entities);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().Update(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task UpdateRangeAsync(IReadOnlyCollection<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _context.Set<TEntity>().UpdateRange(entities);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
