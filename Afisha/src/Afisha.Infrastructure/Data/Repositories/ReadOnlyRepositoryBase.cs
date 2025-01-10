using Afisha.Application.Contracts.Repositories;
using Afisha.Application.Contracts.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Afisha.Infrastructure.Data.Repositories;

public abstract class ReadOnlyRepositoryBase<TEntity> : IReadOnlyRepository<TEntity>, ISpecificationRepository<TEntity> where TEntity : class
{
    protected readonly AfishaDbContext _context;

    protected ReadOnlyRepositoryBase(AfishaDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public virtual async Task<TEntity> GetByIdAsync<TKey>(TKey id, CancellationToken cancellationToken = default) where TKey : struct
    {
        return await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual async Task<TEntity> GetBySpecificationAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync(cancellationToken);
    }

    public virtual async Task<List<TEntity>> ListAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    public virtual async Task<List<TEntity>> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification).ToListAsync(cancellationToken);
    }

    private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
    {
        if (specification is null)
        {
            throw new ArgumentNullException(nameof(specification));
        }

        return specification.ApplyTo(_context.Set<TEntity>().AsQueryable());
    }
}