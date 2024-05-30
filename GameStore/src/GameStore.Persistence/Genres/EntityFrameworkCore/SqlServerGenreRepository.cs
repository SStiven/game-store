using GameStore.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence.Genres.EntityFrameworkCore;

public class SqlServerGenreRepository(GameStoreSqlServerDbContext dbContext) : IGenreRepository
{
    private readonly GameStoreSqlServerDbContext _dbContext = dbContext;

    public async Task<bool> AreAllPresentAsync(IEnumerable<Guid> genreIds)
    {
        var genreCount = await _dbContext.Genres
                .Where(g => genreIds.Contains(g.Id))
                .CountAsync();

        return genreCount == genreIds.Count();
    }
}
