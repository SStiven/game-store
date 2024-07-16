using GameStore.Domain.Bans;

using MediatR;

namespace GameStore.Application.Comments.Queries;

public class GetBanDurationsQueryHandler : IRequestHandler<GetBanDurationsQuery, IReadOnlyList<BanDuration>>
{
    public Task<IReadOnlyList<BanDuration>> Handle(GetBanDurationsQuery request, CancellationToken cancellationToken)
    {
        var banDurations = Enum.GetValues(typeof(BanDuration)).Cast<BanDuration>().ToList().AsReadOnly();
        return Task.FromResult((IReadOnlyList<BanDuration>)banDurations);
    }
}
