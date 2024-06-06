using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.Application.Platforms.Queries;

public class ListAllPlatformsQueryHandler(IPlatformRepository platformRepository)
    : IRequestHandler<ListAllPlatformsQuery, IReadOnlyList<Platform>>
{
    private readonly IPlatformRepository _platformRepository = platformRepository;

    public async Task<IReadOnlyList<Platform>> Handle(ListAllPlatformsQuery request, CancellationToken cancellationToken)
    {
        return await _platformRepository.GetAllAsync();
    }
}
