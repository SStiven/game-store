using ErrorOr;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public record ListGamesWithPlatformIdQuery(Guid PlatformId) : IRequest<ErrorOr<IReadOnlyList<Game>>>;