using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Platforms;
using Microsoft.EntityFrameworkCore;
using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence.EntityFrameworkCore.Repositories;

public class SqlServerPlatformRepository(GameStoreSqlServerDbContext dbContext) : IPlatformRepository
{
    private readonly GameStoreSqlServerDbContext _dbContext = dbContext;

    public async Task<Platform> AddAsync(Platform platform)
    {
        await _dbContext.Platforms.AddAsync(platform);
        return platform;
    }

    public async Task<bool> AreAllPresentAsync(IEnumerable<Guid> platformIds)
    {
        var genreCount = await _dbContext.Platforms
            .Where(p => platformIds.Contains(p.Id))
            .CountAsync();

        return genreCount == platformIds.Count();
    }

    public async Task<IReadOnlyList<Platform>> GetAllAsync()
    {
        return await _dbContext.Platforms
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Platform>> GetByGameIdAsync(Guid gameId)
    {
        return await _dbContext.Platforms
            .Where(p => p.GamePlatforms.Any(gp => gp.GameId == gameId))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Platform?> GetByIdAsync(Guid id)
    {
        return await _dbContext
            .Platforms
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Platform?> GetByTypeAsync(string type)
    {
        return await _dbContext
            .Platforms
            .FirstOrDefaultAsync(p => p.Type == type);
    }

    public Task RemoveAsync(Platform platform)
    {
        _dbContext.Platforms.Remove(platform);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Platform platform)
    {
        _dbContext.Update(platform);
        return Task.CompletedTask;
    }
}
