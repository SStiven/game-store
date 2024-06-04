using ErrorOr;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Commands.UpdateGame;

public record UpdateGameCommand(
    Guid Id,
    string Name,
    string? Key,
    string? Description,
    IEnumerable<Guid> GenreIds,
    IEnumerable<Guid> PlatformIds) : IRequest<ErrorOr<Game>>;