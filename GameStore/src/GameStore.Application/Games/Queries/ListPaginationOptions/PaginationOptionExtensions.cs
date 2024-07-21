namespace GameStore.Application.Games.Queries.ListPaginationOptions;

public static class PaginationOptionExtensions
{
    public static string ToDisplayString(this PaginationOptions paginationOption)
    {
        return paginationOption switch
        {
            PaginationOptions.Ten => "10",
            PaginationOptions.Twenty => "20",
            PaginationOptions.Fifty => "50",
            PaginationOptions.OneHundred => "100",
            PaginationOptions.All => "all",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public static PaginationOptions FromString(string paginationOption)
    {
        return paginationOption switch
        {
            "10" => PaginationOptions.Ten,
            "20" => PaginationOptions.Twenty,
            "50" => PaginationOptions.Fifty,
            "100" => PaginationOptions.OneHundred,
            "all" => PaginationOptions.All,
            _ => throw new ArgumentException("Invalid pagination option"),
        };
    }
}