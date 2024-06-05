using ErrorOr;
using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.Application.Platforms.Commands.UpdatePlatform;

public record UpdatePlatformCommand(Guid Id, string Type) : IRequest<ErrorOr<Platform>>;