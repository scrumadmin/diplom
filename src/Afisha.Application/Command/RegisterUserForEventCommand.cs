namespace Afisha.Application.Command;

public class RegisterUserForEventCommand
{
    public Guid UserId { get; set; }
    public Guid EventId { get; set; }
}
