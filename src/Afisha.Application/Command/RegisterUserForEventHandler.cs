using Afisha.Domain.Contracts;

namespace Afisha.Application.Command;

public class RegisterUserForEventHandler
{
    private readonly IUserRepository _userRepository;

    public RegisterUserForEventHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Handle(RegisterUserForEventCommand command)
    {
        var user = _userRepository.GetById(command.UserId);
    }
}