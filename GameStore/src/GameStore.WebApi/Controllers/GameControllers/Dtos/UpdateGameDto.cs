namespace GameStore.WebApi.Controllers.GameControllers.Dtos;

public record UpdateGameDto(
    Guid Id,
    string Name,
    string? Key,
    string? Description,
    double Price,
    int UnitInStock,
    int Discount);