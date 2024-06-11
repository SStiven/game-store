using GameStore.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace GameStore.Persistence.Common.InMemoryCache;
public class InMemoryCacheService(IMemoryCache memoryCache, ISystemClock systemClock) : ICacheService
{
    private const int _minutesInCache = 1;
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly ISystemClock _systemClock = systemClock;

    public T? Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);
    }

    public bool Has<T>(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    public void AddOrUpdate<T>(string key, T value)
        where T : notnull
    {
        _memoryCache.Set(key, value, _systemClock.UtcNow.AddMinutes(_minutesInCache));
    }
}
