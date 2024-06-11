using GameStore.Application.Common.Interfaces;

namespace GameStore.Infrastructure.DateTimeServices;

public class SystemClock : ISystemClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
