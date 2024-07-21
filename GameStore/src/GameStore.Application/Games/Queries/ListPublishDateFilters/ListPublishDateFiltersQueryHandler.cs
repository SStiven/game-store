using MediatR;

namespace GameStore.Application.Games.Queries.ListPublishDateFilters;

public class ListPublishDateFiltersQueryHandler
    : IRequestHandler<ListPublishDateFiltersQuery, IEnumerable<PublishDateFilters>>
{
    public Task<IEnumerable<PublishDateFilters>> Handle(ListPublishDateFiltersQuery request, CancellationToken cancellationToken)
    {
        var publishDateFilters = Enum.GetValues(typeof(PublishDateFilters)).Cast<PublishDateFilters>().ToArray();
        return Task.FromResult<IEnumerable<PublishDateFilters>>(publishDateFilters);
    }
}
