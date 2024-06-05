using ErrorOr;
using MediatR;

namespace GameStore.Application.Platforms.Commands.DeletePlatform;

public record DeletePlatformCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;