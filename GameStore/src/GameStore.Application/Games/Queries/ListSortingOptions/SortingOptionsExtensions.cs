namespace GameStore.Application.Games.Queries.ListSortingOptions;

public static class SortingOptionsExtensions
{
    public static string ToDisplayString(this SortingOptions sortingOptions)
    {
        return sortingOptions switch
        {
            SortingOptions.MostPopular => "Most popular",
            SortingOptions.MostCommented => "Most commented",
            SortingOptions.PriceAsc => "Price ASC",
            SortingOptions.PriceDesc => "Price DESC",
            SortingOptions.New => "New",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public static SortingOptions FromString(string sortingOption)
    {
        return sortingOption switch
        {
            "Most popular" => SortingOptions.MostPopular,
            "Most commented" => SortingOptions.MostCommented,
            "Price ASC" => SortingOptions.PriceAsc,
            "Price DESC" => SortingOptions.PriceDesc,
            "New" => SortingOptions.New,
            _ => throw new ArgumentException("Invalid sorting option"),
        };
    }
}
