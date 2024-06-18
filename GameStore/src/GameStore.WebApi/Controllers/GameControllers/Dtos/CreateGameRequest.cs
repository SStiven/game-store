namespace GameStore.WebApi.Controllers.GameController.Dtos;

public record CreateGameRequest(
    CreateGameDto Game,
    IEnumerable<Guid> Genres,
    IEnumerable<Guid> Platforms,
    Guid Publisher);
