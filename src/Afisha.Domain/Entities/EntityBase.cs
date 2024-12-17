namespace Afisha.Domain.Entities;

public class EntityBase<TKey> where TKey : struct
{
    public TKey Id { get; set; }
}
