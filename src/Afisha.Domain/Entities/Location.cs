namespace Afisha.Domain.Entities;

public class Location : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
