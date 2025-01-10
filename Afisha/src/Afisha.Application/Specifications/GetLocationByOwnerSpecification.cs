using Afisha.Domain.Entities;

namespace Afisha.Application.Specifications
{
    public class GetLocationByOwnerSpecification : SpecificationBase<Location>
    {
        public GetLocationByOwnerSpecification(long owner)
            :base(query => query
            .Where(location => location.Owner.Id == owner))
        { }
    }
}
