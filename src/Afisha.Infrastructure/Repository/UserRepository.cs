using Afisha.Domain.Contracts;
using Afisha.Domain.Entities;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public User GetById(Guid id)
    {
        return _context.Users.Find(id);
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
