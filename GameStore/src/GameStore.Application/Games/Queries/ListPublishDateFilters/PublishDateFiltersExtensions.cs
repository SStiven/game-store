using GameStore.Application.Games.Queries.ListPublishDateFilters;

namespace GameStore.Application.Games.Queries.ListPaginationOptions;

public static class PublishDateFiltersExtensions
{
    public static string ToDisplayString(this PublishDateFilters publishDateFilter)
    {
        return publishDateFilter switch
        {
            PublishDateFilters.LastWeek => "last week",
            PublishDateFilters.LastMonth => "last month",
            PublishDateFilters.LastYear => "last year",
            PublishDateFilters.TwoYears => "2 years",
            PublishDateFilters.ThreeYears => "3 years",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public static PublishDateFilters FromString(string publishDateFilter)
    {
        return publishDateFilter switch
        {
            "last week" => PublishDateFilters.LastWeek,
            "last month" => PublishDateFilters.LastMonth,
            "last year" => PublishDateFilters.LastYear,
            "2 years" => PublishDateFilters.TwoYears,
            "3 years" => PublishDateFilters.ThreeYears,
            _ => throw new ArgumentException("Invalid publish date filter"),
        };
    }
}