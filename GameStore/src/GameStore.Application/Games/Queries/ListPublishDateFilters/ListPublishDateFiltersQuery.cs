using MediatR;

namespace GameStore.Application.Games.Queries.ListPublishDateFilters;

public record ListPublishDateFiltersQuery : IRequest<IEnumerable<PublishDateFilters>>;
