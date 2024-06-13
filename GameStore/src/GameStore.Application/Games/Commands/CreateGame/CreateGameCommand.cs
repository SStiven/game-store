using ErrorOr;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Commands.CreateGame;

public record CreateGameCommand(
    string Name,
    string? Key,
    string? Description,
    IEnumerable<Guid> GenreIds,
    IEnumerable<Guid> PlatformIds) : IRequest<ErrorOr<Game>>;