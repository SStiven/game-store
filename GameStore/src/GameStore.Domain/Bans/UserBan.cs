namespace GameStore.Domain.Bans;

public class UserBan
{
    public UserBan(string userName, BanDuration banDuration, DateTime dateTimeNow)
    {
        Id = Guid.NewGuid();

        ArgumentException.ThrowIfNullOrEmpty(userName);
        UserName = userName;

        ExpirationDate = CalculateExpirationDate(banDuration, dateTimeNow);
    }

    private UserBan()
    {
    }

    public Guid Id { get; }

    public string UserName { get; }

    public DateTime ExpirationDate { get; private set; }

    public void AddDuration(BanDuration banDuration, DateTime dateTimeNow)
    {
        var baseDate = dateTimeNow > ExpirationDate ? dateTimeNow : ExpirationDate;
        ExpirationDate = CalculateExpirationDate(banDuration, baseDate);
    }

    public bool HasExpired(DateTime dateTimeNow)
    {
        return dateTimeNow > ExpirationDate;
    }

    private static DateTime CalculateExpirationDate(BanDuration banDuration, DateTime dateTimeNow)
    {
        return banDuration switch
        {
            BanDuration.Permanent => DateTime.MaxValue,
            BanDuration.OneHour => dateTimeNow.AddHours(1),
            BanDuration.OneDay => dateTimeNow.AddDays(1),
            BanDuration.OneWeek => dateTimeNow.AddDays(7),
            BanDuration.OneMonth => dateTimeNow.AddMonths(1),
            _ => throw new ArgumentException("Invalid ban duration"),
        };
    }
}
