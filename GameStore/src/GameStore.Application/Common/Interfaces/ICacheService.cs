namespace GameStore.Application.Common.Interfaces;

public interface ICacheService
{
    T? Get<T>(string key);

    bool Has<T>(string key);

    void AddOrUpdate<T>(string key, T value)
        where T : notnull;
}
