using ErrorOr;
using GameStore.Application.Games.Queries;
using GameStore.Application.Genres.Commands;
using GameStore.Application.Genres.Commands.DeleteGame;
using GameStore.Application.Genres.Commands.UpdateGenre;
using GameStore.Application.Genres.Queries;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using GameStore.WebApi.Controllers.GenreControllers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.PlatformControllers;

[Route("genres")]
public class GenresController(ISender mediator) : ControllerErrorOr
{
    private readonly ISender _mediator = mediator;

    [HttpGet("{id}/games")]
    public async Task<IActionResult> GetGamesByGenreId(Guid id)
    {
        var result = await _mediator.Send(new ListGamesWithGenreIdQuery(id));
        return result.IsError
            ? Problem(result.Errors)
            : Ok(result.Value.Select(game => new GameResponse(
                game.Id,
                game.Name,
                game.Key,
                game.Description,
                game.Price,
                game.UnitInStock,
                game.Discount)));
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetGenreByIdQuery(id));
        return result.IsError
            ? Problem(result.Errors)
            : Ok(new GenreResponseWithParentId(
                result.Value.Id,
                result.Value.Name,
                result.Value.ParentGenreId));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var genres = await _mediator.Send(new ListAllGenresQuery());

        return Ok(genres.Select(g => new GenreResponse(g.Id, g.Name)));
    }

    [HttpGet("{id}/genres")]
    public async Task<IActionResult> GetGenresByParentGenreId(Guid id)
    {
        var result = await _mediator.Send(new ListGenresByParentGenreIdQuery(id));
        return result.IsError
            ? Problem(result.Errors)
            : Ok(result.Value.Select(g => new GenreResponse(g.Id, g.Name)));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteGenreCommand = new DeleteGenreCommand(id);
        var deleteGenreResult = await _mediator.Send(deleteGenreCommand);

        return deleteGenreResult.Match(
            _ => NoContent(),
            Problem);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateGenreRequest request)
    {
        if (string.IsNullOrEmpty(request.Genre.Name))
        {
            return Problem(Error.Validation(description: "Name is required"));
        }

        if (request.Genre.Name.Length > 100)
        {
            return Problem(Error.Validation(description: "Name is too long, maximum length is 100 characters"));
        }

        var updateGenreCommand = new UpdateGenreCommand(request.Genre.Id, request.Genre.Name, request.Genre.ParentGenreId);
        var updateGenreResult = await _mediator.Send(updateGenreCommand);

        return updateGenreResult.Match(
            genre => Ok(new GenreResponseWithParentId(
                genre.Id,
                genre.Name,
                genre.ParentGenreId)),
            Problem);
    }
}
