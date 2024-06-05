using ErrorOr;
using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.Application.Platforms.Commands.CreatePlatform;

public record CreatePlatformCommand(string Type) : IRequest<ErrorOr<Platform>>;