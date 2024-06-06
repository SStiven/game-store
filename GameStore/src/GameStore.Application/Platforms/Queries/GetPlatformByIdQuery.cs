using ErrorOr;
using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.Application.Platforms.Queries;
public record GetPlatformByIdQuery(Guid Id) : IRequest<ErrorOr<Platform>>;
