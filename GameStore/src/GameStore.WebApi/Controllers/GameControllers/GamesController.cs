using ErrorOr;

using FluentValidation;

using GameStore.Application.Comments.Commands.DeleteComment;
using GameStore.Application.Games.Commands.CreateGame;
using GameStore.Application.Games.Commands.DeleteGame;
using GameStore.Application.Games.Commands.UpdateGame;
using GameStore.Application.Games.Queries;
using GameStore.Application.Genres.Queries;
using GameStore.Application.Platforms.Queries;
using GameStore.Application.Publishers.Queries;
using GameStore.Domain.Games;
using GameStore.WebApi.Controllers.GameController.Dtos;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using GameStore.WebApi.Controllers.GenreControllers.Dtos;
using GameStore.WebApi.Controllers.PlatformControllers.Dtos;
using GameStore.WebApi.Controllers.PublisherControllers.Dtos;

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
        var command = new CreateGameCommand(
            request.Game.Name,
            request.Game.Key,
            request.Game.Description,
            request.Game.Price,
            request.Game.UnitInStock,
            request.Game.Discount,
            request.Genres,
            request.Platforms,
            request.Publisher);

        var result = await _mediator.Send(command);

        return result.Match(
            game => CreatedAtAction(nameof(Create), new GameResponse(
                game.Id,
                game.Name,
                game.Key,
                game.Description,
                game.Price,
                game.UnitInStock,
                game.Discount)),
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
                game.Description,
                game.Price,
                game.UnitInStock,
                game.Discount)),
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
                game.Description,
                game.Price,
                game.UnitInStock,
                game.Discount)),
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
             request.Game.Price,
             request.Game.UnitInStock,
             request.Game.Discount,
             request.Genres,
             request.Platforms,
             request.Publisher);

        var updateGameResult = await _mediator.Send(updateGameCommand);

        return updateGameResult.Match(
            game => Ok(new GameResponse(
                game.Id,
                game.Name,
                game.Key,
                game.Description,
                game.Price,
                game.UnitInStock,
                game.Discount)),
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

        return Ok(games.Select(game => new GameResponse(
                game.Id,
                game.Name,
                game.Key,
                game.Description,
                game.Price,
                game.UnitInStock,
                game.Discount)));
    }

    [HttpGet("{gameKey}/genres")]
    public async Task<IActionResult> GetGenresByGameKey(string gameKey)
    {
        var result = await _mediator.Send(new ListGenresByGameKeyQuery(gameKey));

        return result.Match(
            genres => Ok(genres.Select(g => new GenreResponse(
                g.Id,
                g.Name))),
            Problem);
    }

    [HttpGet("{key}/file")]
    public async Task<IActionResult> DownloadGameFile(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return Problem(Error.Validation("The key can't be null or empty"));
        }

        if (key.Length > 150)
        {
            return Problem(Error.Validation(description: "The key must be 150 characters long or less"));
        }

        var result = await _mediator.Send(new GetGameFileBytesByKeyQuery(key));
        return result.Match(
            bytes => File(bytes, "application/octet-stream", $"{key}"),
            Problem);
    }

    [HttpGet("{key}/platforms")]
    public async Task<IActionResult> GetPlatformsByGameKey(string key)
    {
        var result = await _mediator.Send(new ListPlatformsByGameKeyQuery(key));

        return result.Match(
            platforms => Ok(platforms.Select(p => new PlatformResponse(
                p.Id,
                p.Type))),
            Problem);
    }

    [HttpGet("{key}/publisher")]
    public async Task<IActionResult> GetPublisherByGameKey(string key)
    {
        var result = await _mediator.Send(new GetPublisherByGameKeyQuery(key));

        return result.Match(
            publisher => Ok(new PublisherResponse(
                publisher.Id,
                publisher.CompanyName,
                publisher.HomePage,
                publisher.Description)),
            Problem);
    }

    [HttpDelete("{key}/comments/{id}")]
    public async Task<IActionResult> DeleteComment(string key, Guid id)
    {
        var result = await _mediator.Send(new DeleteCommentCommand(key, id));

        return result.Match(
            _ => NoContent(),
            Problem);
    }
}
