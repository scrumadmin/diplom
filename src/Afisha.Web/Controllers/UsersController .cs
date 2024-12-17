using Afisha.Application.Command;
using Microsoft.AspNetCore.Mvc;

namespace Afisha.Web.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    public UsersController()
    {
    }

    [HttpPost("{userId}/events/{eventId}")]
    public IActionResult RegisterForEvent(Guid userId, Guid eventId)
    {
        var command = new RegisterUserForEventCommand
        {
            UserId = userId,
            EventId = eventId
        };        

        // send command

        return Ok();
    }
}