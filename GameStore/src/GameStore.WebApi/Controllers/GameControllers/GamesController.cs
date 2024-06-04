using ErrorOr;
using FluentValidation;
using GameStore.Application.Games.Commands.CreateGame;
using GameStore.Application.Games.Commands.DeleteGame;
using GameStore.Application.Games.Commands.UpdateGame;
using GameStore.Application.Games.Queries;
using GameStore.Domain.Games;
using GameStore.WebApi.Controllers.GameController.Dtos;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.GameControllers;

[Route("games")]
public class GamesController(
    IValidator<CreateGameRequest> createGameValidator,
    IValidator<UpdateGameRequest> updateGameValidator,
    IMediator mediator) : ControllerErrorOr
{
    private readonly IValidator<CreateGameRequest> _createGameValidator = createGameValidator;
    private readonly IValidator<UpdateGameRequest> _updateGameValidator = updateGameValidator;
    private readonly ISender _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(CreateGameRequest request)
    {
        var validationResult = await _createGameValidator.ValidateAsync(request);

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

    [HttpPut]
    public async Task<IActionResult> UpdateGame(UpdateGameRequest request)
    {
        var validationResult = await _updateGameValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var updateGameCommand = new UpdateGameCommand(
             request.Game.Id,
             request.Game.Name,
             request.Game.Key,
             request.Game.Description,
             request.Genres,
             request.Platforms);

        var updateGameResult = await _mediator.Send(updateGameCommand);

        return updateGameResult.Match(
            game => Ok(new GameResponse(
                game.Id,
                game.Name,
                game.Key,
                game.Description)),
            Problem);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(Guid id)
    {
        var result = await _mediator.Send(new DeleteGameCommand(id));

        return result.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpGet("/gamesType")]
    public async Task<IActionResult> GetAll()
    {
        IReadOnlyList<Game> games = await _mediator.Send(new ListAllGamesQuery());

        return Ok(games.Select(g => new GameResponse(
                g.Id,
                g.Name,
                g.Key,
                g.Description)));
    }
}
