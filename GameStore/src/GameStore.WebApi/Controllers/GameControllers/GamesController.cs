using ErrorOr;
using FluentValidation;
using GameStore.Application.Games.Commands.CreateGame;
using GameStore.Application.Games.Queries;
using GameStore.WebApi.Controllers.GameController.Dtos;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.GameControllers;

[Route("games")]
public class GamesController(
    IValidator<CreateGameRequest> gameValidator,
    IMediator mediator) : ControllerErrorOr
{
    private readonly IValidator<CreateGameRequest> _validator = gameValidator;
    private readonly ISender _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(CreateGameRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var createGameCommand = new CreateGameCommand
        {
            Name = request.Game.Name,
            Key = request.Game.Key,
            Description = request.Game.Description,
            GenreIds = request.Genres,
            PlatformIds = request.Platforms,
        };

        var createGameResult = await _mediator.Send(createGameCommand);

        return createGameResult.Match(
            game => CreatedAtAction(nameof(Create), new GameResponse(
                game.Id,
                game.Name,
                game.Key,
                game.Description)),
            Problem);
    }

    [HttpGet("key/{key}")]
    public async Task<IActionResult> GetGameByKey(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            return Problem(Error.Validation(description: "Key is required"));
        }

        var result = await _mediator.Send(new GetGameByKeyQuery(key));

        return result.Match(
            game => Ok(
                new GameResponse(
                game.Id,
                game.Name,
                game.Key,
                game.Description)),
            Problem);
    }

    [HttpGet("find/{id}")]
    public async Task<IActionResult> GetGameById(Guid id)
    {
        var result = await _mediator.Send(new GetGameByIdQuery(id));

        return result.Match(
            game => Ok(new GameResponse(
                game.Id,
                game.Name,
                game.Key,
                game.Description)),
            Problem);
    }
}
