namespace Afisha.Application.Contracts.Specifications;

public interface ISpecification<TResult> where TResult : class
{
    IQueryable<TResult> ApplyTo(IQueryable<TResult> set);
}
