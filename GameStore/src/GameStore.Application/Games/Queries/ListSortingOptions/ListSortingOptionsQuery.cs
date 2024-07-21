using MediatR;

namespace GameStore.Application.Games.Queries.ListSortingOptions;

public record ListSortingOptionsQuery : IRequest<IEnumerable<SortingOptions>>;