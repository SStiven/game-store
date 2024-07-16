namespace GameStore.Domain.Bans;

public static class BanDurationExtensions
{
    public static string ToDisplayString(this BanDuration duration)
    {
        return duration switch
        {
            BanDuration.OneHour => "1 hour",
            BanDuration.OneDay => "1 day",
            BanDuration.OneWeek => "1 week",
            BanDuration.OneMonth => "1 month",
            BanDuration.Permanent => "permanent",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }

    public static BanDuration FromString(string duration)
    {
        return duration.ToLowerInvariant() switch
        {
            "1 hour" => BanDuration.OneHour,
            "1 day" => BanDuration.OneDay,
            "1 week" => BanDuration.OneWeek,
            "1 month" => BanDuration.OneMonth,
            "permanent" => BanDuration.Permanent,
            _ => throw new ArgumentException("Invalid ban duration"),
        };
    }
}
