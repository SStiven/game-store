using MediatR;

namespace GameStore.Application.Games.Queries.ListSortingOptions;

public class ListSortingOptionsQueryHandler : IRequestHandler<ListSortingOptionsQuery, IEnumerable<SortingOptions>>
{
    public Task<IEnumerable<SortingOptions>> Handle(ListSortingOptionsQuery request, CancellationToken cancellationToken)
    {
        var sortingOptions = Enum.GetValues(typeof(SortingOptions)).Cast<SortingOptions>().ToArray();
        return Task.FromResult<IEnumerable<SortingOptions>>(sortingOptions);
    }
}
