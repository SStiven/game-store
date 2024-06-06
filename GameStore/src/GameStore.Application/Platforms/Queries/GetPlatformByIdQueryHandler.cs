using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.Application.Platforms.Queries;

public class GetPlatformByIdQueryHandler(IPlatformRepository platformRepository)
    : IRequestHandler<GetPlatformByIdQuery, ErrorOr<Platform>>
{
    private readonly IPlatformRepository _platformRepository = platformRepository;

    public async Task<ErrorOr<Platform>> Handle(GetPlatformByIdQuery request, CancellationToken cancellationToken)
    {
        var platform = await _platformRepository.GetByIdAsync(request.Id);
        return platform == null
            ? Error.Validation(description: $"Platform with id {request.Id} not found")
            : platform;
    }
}
