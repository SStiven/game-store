namespace GameStore.WebApi.Controllers.GameControllers.Dtos;
public record CreateGameDto(
    string Name,
    string? Key,
    string? Description,
    double Price,
    int UnitInStock,
    int Discount);