using GameStore.Domain.Games;

using MediatR;

namespace GameStore.Application.Games.Queries.ListFiltered;

public record ListFilteredGamesQuery(
    string? Name,
    IReadOnlyList<Guid>? Platforms,
    IReadOnlyList<Guid>? Genres,
    IReadOnlyList<Guid>? Publishers,
    int? MaxPrice,
    int? MinPrice,
    string? Sort,
    int? Page,
    int? PageCount)
    : IRequest<IEnumerable<Game>>;
