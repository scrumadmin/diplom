using Afisha.Application.Contracts.Specifications;

namespace Afisha.Application.Specifications;

public abstract class SpecificationBase<TResult>(Func<IQueryable<TResult>, IQueryable<TResult>> query) : ISpecification<TResult> where TResult : class
{
    public IQueryable<TResult> ApplyTo(IQueryable<TResult> set)
    {
        if (set is null)
        {
            throw new ArgumentNullException(nameof(set));
        }

        return query(set);
    }
}
