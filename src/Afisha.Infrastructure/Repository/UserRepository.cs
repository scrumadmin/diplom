using Afisha.Domain.Contracts;
using Afisha.Domain.Entities;

public class UserRepository : IUserRepository
{
    User IUserRepository.GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public void Save(User user)
    {
        throw new NotImplementedException();
    }
}
