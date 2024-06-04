namespace GameStore.WebApi.Controllers.GameControllers.Dtos;

public record UpdateGameRequest(
    UpdateGameDto Game,
    IEnumerable<Guid> Genres,
    IEnumerable<Guid> Platforms);