namespace Afisha.Domain.Entities
{
    public class User : EntityBase<long>
    {
        public long Id { get; set; } // можно сделать guid, например, или int
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public int Age { get; set; }
    }
}
