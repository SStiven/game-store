using ErrorOr;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Commands.UpdateGame;

public record UpdateGameCommand(
    Guid Id,
    string Name,
    string? Key,
    string? Description,
    double Price,
    int UnitInStock,
    int Discount,
    IEnumerable<Guid> GenreIds,
    IEnumerable<Guid> PlatformIds,
    Guid PublisherId) : IRequest<ErrorOr<Game>>;