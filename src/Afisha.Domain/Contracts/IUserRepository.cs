using Afisha.Domain.Entities;

namespace Afisha.Domain.Contracts;

public interface IUserRepository
{
    User GetById(Guid id);
    void Add(User user);
    void Save(User user);
}
