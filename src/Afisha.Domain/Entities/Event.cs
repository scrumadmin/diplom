namespace Afisha.Domain.Entities;

public class Event : EntityBase<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
