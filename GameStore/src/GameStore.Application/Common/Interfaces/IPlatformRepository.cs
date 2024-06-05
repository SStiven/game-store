using GameStore.Domain.Platforms;

namespace GameStore.Application.Common.Interfaces;

public interface IPlatformRepository
{
    Task<Platform> AddAsync(Platform platform);

    Task<bool> AreAllPresentAsync(IEnumerable<Guid> platformIds);

    Task<Platform?> GetByTypeAsync(string type);
}
