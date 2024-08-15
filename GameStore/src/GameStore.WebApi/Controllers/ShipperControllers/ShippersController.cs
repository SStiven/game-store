using GameStore.Application.Shippers.Queries.ListAll;
using GameStore.WebApi.Controllers.ShipperControllers.Dtos;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.PlatformControllers;

[Route("shippers")]
public class ShippersController(ISender mediator) : ControllerErrorOr
{
    private readonly ISender _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new ListAllShippersQuery());
        return Ok(result.Select(p => new ShipperResponse(
            p.Id,
            p.CompanyName,
            p.Phone)));
    }
}
