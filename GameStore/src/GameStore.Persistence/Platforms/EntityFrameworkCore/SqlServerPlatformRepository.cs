using GameStore.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence.EntityFrameworkCore.Repositories;

public class SqlServerPlatformRepository(GameStoreSqlServerDbContext dbContext) : IPlatformRepository
{
    private readonly GameStoreSqlServerDbContext _dbContext = dbContext;

    public async Task<bool> AreAllPresentAsync(IEnumerable<Guid> platformIds)
    {
        var genreCount = await _dbContext.Platforms
            .Where(p => platformIds.Contains(p.Id))
            .CountAsync();

        return genreCount == platformIds.Count();
    }
}
