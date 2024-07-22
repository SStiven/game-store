using GameStore.Application.Games.Queries.ListPaginationOptions;
using GameStore.Application.Games.Queries.ListPublishDateFilters;
using GameStore.Application.Games.Queries.ListSortingOptions;

namespace GameStore.Application.Games.Queries.ListFiltered;

public class FilterParameters
{
    public FilterParameters()
    {
        Name = string.Empty;
        DatePublishing = PublishDateFilters.LastMonth;
        Sort = SortingOptions.PriceAsc;
        Page = PaginationOptions.Ten;
        var empty = new List<Guid>();
        Platforms = empty;
        Genres = empty;
        Publishers = empty;
    }

    public string? Name { get; set; }

    public IReadOnlyList<Guid> Platforms { get; set; }

    public IReadOnlyList<Guid> Genres { get; set; }

    public IReadOnlyList<Guid> Publishers { get; set; }

    public double? MaxPrice { get; set; }

    public double? MinPrice { get; set; }

    public PublishDateFilters? DatePublishing { get; set; }

    public SortingOptions? Sort { get; set; }

    public PaginationOptions? Page { get; set; }

    public int? PageCount { get; set; }
}
