using ErrorOr;
using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.WebApi.Controllers.PlatformControllers.Dtos;

public record CreatePlatformCommand(string Type) : IRequest<ErrorOr<Platform>>;