using Afisha.Domain.Contracts;
using Afisha.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Afisha.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController(ILocationService locationService) : ControllerBase
{
    [HttpGet]
    public async Task<Location> Get([FromQuery] long id)
    {
        return await locationService.GetLocationByIdAsync(id, HttpContext.RequestAborted);
    }

    [HttpPost]
    [Route("create")]
    public async Task<Location> CreateLocation([FromBody] Location newLocation)
    {
        //TODO Нужно будет добавить в инфрасруктуру какой-нибудь сервис-экстрактор токена
        var ownerId = newLocation.Owner.Id;

        var result = await locationService.CreateLocation(newLocation, ownerId, HttpContext.RequestAborted);
        return result;
    }

    [HttpGet]
    [Route("byOwner")]
    public async Task<List<Location>> LocationByOuner([FromQuery] long owner)
    {
        var result = await locationService.GetLocationsByOwnerAsync(owner, HttpContext.RequestAborted);
        return result;
    }
}