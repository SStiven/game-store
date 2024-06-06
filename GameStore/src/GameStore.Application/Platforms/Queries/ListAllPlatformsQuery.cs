using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.Application.Platforms.Queries;

public record ListAllPlatformsQuery() : IRequest<IReadOnlyList<Platform>>;
