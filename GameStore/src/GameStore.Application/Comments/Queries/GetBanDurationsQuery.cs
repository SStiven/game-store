using GameStore.Domain.Bans;

using MediatR;

namespace GameStore.Application.Comments.Queries;

public record GetBanDurationsQuery : IRequest<IReadOnlyList<BanDuration>>;
