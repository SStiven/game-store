using GameStore.Domain.Platforms;

namespace GameStore.Application.Common.Interfaces;

public interface IPlatformRepository
{
    Task<Platform> AddAsync(Platform platform);

    Task<bool> AreAllPresentAsync(IEnumerable<Guid> platformIds);

    Task<Platform?> GetByIdAsync(Guid id);

    Task<Platform?> GetByTypeAsync(string type);

    Task RemoveAsync(Platform platform);

    Task UpdateAsync(Platform platform);
}
