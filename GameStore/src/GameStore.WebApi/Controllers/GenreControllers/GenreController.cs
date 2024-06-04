using GameStore.Application.Games.Queries;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.PlatformControllers;

[Route("genres")]
public class GenreController(ISender mediator) : ControllerErrorOr
{
    private readonly ISender _mediator = mediator;

    [HttpGet("{id}/games")]
    public async Task<IActionResult> GetGamesByGenreId(Guid id)
    {
        var result = await _mediator.Send(new ListGamesWithGenreIdQuery(id));
        return result.IsError
            ? Problem(result.Errors)
            : Ok(result.Value.Select(g => new GameResponse(
                g.Id,
                g.Name,
                g.Key,
                g.Description)));
    }
}
