using ErrorOr;
using GameStore.Application.Games.Queries;
using GameStore.Application.Platforms.Commands.CreatePlatform;
using GameStore.Application.Platforms.Commands.DeletePlatform;
using GameStore.Application.Platforms.Commands.UpdatePlatform;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using GameStore.WebApi.Controllers.PlatformControllers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.PlatformControllers;

[Route("platforms")]
public class PlatformsController(ISender mediator) : ControllerErrorOr
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

    [HttpPost]
    public async Task<IActionResult> CreatePlatform([FromBody] CreatePlatformRequest request)
    {
        if (string.IsNullOrEmpty(request.Platform.Type))
        {
            return Problem(Error.Validation(description: "Type cannot be null or empty"));
        }

        if (request.Platform.Type.Length > 200)
        {
            return Problem(Error.Validation(description: "Type cannot be longer than 200 characters"));
        }

        var result = await _mediator.Send(new CreatePlatformCommand(request.Platform.Type));
        return result.Match(
            platform => CreatedAtAction(nameof(CreatePlatform), new PlatformResponse(
                platform.Id,
                platform.Type)),
            Problem);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePlatform([FromBody] UpdatePlatformRequest request)
    {
        if (string.IsNullOrEmpty(request.Platform.Type))
        {
            return Problem(Error.Validation(description: "Type cannot be null or empty"));
        }

        if (request.Platform.Type.Length > 200)
        {
            return Problem(Error.Validation(description: "Type cannot be longer than 200 characters"));
        }

        var result = await _mediator.Send(new UpdatePlatformCommand(request.Platform.Id, request.Platform.Type));

        return result.Match(
            platform => Ok(new PlatformResponse(
                platform.Id,
                platform.Type)),
            Problem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlatform(Guid id)
    {
        var result = await _mediator.Send(new DeletePlatformCommand(id));
        return result.Match(
            _ => NoContent(),
            Problem);
    }
}
