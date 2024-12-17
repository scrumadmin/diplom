using Microsoft.AspNetCore.Mvc;

namespace Afisha.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    public UsersController()
    {
    }

    [HttpPost("{userId}/events/{eventId}")]
    public IActionResult RegisterForEvent(Guid userId, Guid eventId)
    {
        return Ok();
    }
}