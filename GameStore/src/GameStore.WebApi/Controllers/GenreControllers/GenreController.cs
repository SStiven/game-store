using ErrorOr;
using GameStore.Application.Games.Queries;
using GameStore.Application.Genres.Commands;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using GameStore.WebApi.Controllers.GenreControllers.Dtos;
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

    [HttpPost]
    public async Task<IActionResult> Create(CreateGenreRequest request)
    {
        if (string.IsNullOrEmpty(request.Genre.Name))
        {
            return Problem(Error.Validation(description: "Name is required"));
        }

        if (request.Genre.Name.Length > 100)
        {
            return Problem(Error.Validation(description: "Name is too long, maximum length is 100 characters"));
        }

        var createGenreCommand = new CreateGenreCommand(request.Genre.Name, request.Genre.ParentGenreId);
        var createGameResult = await _mediator.Send(createGenreCommand);

        return createGameResult.Match(
            game => CreatedAtAction(nameof(Create), new GenreResponse(
                game.Id,
                game.Name)),
            Problem);
    }
}
