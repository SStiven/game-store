using GameStore.Application.Games.Queries;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.PlatformControllers;

[Route("platforms")]
public class PlatformController(ISender mediator) : ControllerErrorOr
{
    private readonly ISender _mediator = mediator;

    [HttpGet("{id}/games")]
    public async Task<IActionResult> GetGameByPlatformId(Guid id)
    {
        var result = await _mediator.Send(new ListGamesWithPlatformIdQuery(id));
        return result.IsError
            ? Problem(result.Errors)
            : Ok(result.Value.Select(g => new GameResponse(
                g.Id,
                g.Name,
                g.Key,
                g.Description)));
    }
}
