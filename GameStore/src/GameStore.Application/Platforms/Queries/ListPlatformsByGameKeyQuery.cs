using ErrorOr;
using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.Application.Platforms.Queries;

public record ListPlatformsByGameKeyQuery(string GameKey) : IRequest<ErrorOr<IReadOnlyList<Platform>>>;
