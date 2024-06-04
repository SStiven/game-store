namespace GameStore.WebApi.Controllers.GameController.Dtos;
public record CreateGameDto(
    string Name,
    string? Key,
    string? Description);