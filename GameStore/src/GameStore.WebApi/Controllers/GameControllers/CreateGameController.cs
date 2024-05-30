using FluentValidation;
using GameStore.Application.Games.Commands.CreateGame;
using GameStore.WebApi.Controllers.GameController.Dtos;
using GameStore.WebApi.Controllers.GameControllers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebApi.Controllers.GameController;

[ApiController]
[Route("games")]
public class CreateGameController(
    IValidator<CreateGameRequest> gameValidator,
    IMediator mediator) : ControllerBase
{
    private readonly IValidator<CreateGameRequest> _validator = gameValidator;
    private readonly ISender _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Create(CreateGameRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult);
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
        if (createGameResult.IsError)
        {
            return Problem();
        }

        var createGameResponse = new CreateGameResponse
        {
            Id = createGameResult.Value.Id,
            Name = createGameResult.Value.Name,
            Key = createGameResult.Value.Key,
            Description = createGameResult.Value.Description,
        };
        return Ok(createGameResponse);
    }
}
