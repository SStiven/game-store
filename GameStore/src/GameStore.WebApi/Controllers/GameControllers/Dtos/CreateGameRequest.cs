namespace GameStore.WebApi.Controllers.GameControllers.Dtos;

public record CreateGameRequest(
    CreateGameDto Game,
    IEnumerable<Guid> Genres,
    IEnumerable<Guid> Platforms,
    Guid Publisher);
