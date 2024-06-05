using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Genres;
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

    public async Task<Genre?> GetByIdAsync(Guid parentGenreId)
    {
        return await _dbContext.Genres.FindAsync(parentGenreId);
    }

    public async Task<Genre> AddAsync(Genre genre)
    {
        await _dbContext.AddAsync(genre);
        return genre;
    }

    public async Task<IReadOnlyList<Genre>> GetAllAsync()
    {
        return await _dbContext.Genres.ToListAsync();
    }

    public async Task<List<Genre>> GetByGameIdAsync(Guid gameId)
    {
        return await _dbContext.Genres
            .Where(g => g.GameGenres.Any(gg => gg.GameId == gameId))
            .ToListAsync();
    }

    public async Task<List<Genre>> GetByParentGenreIdAsync(Guid parentGenreId)
    {
        return await _dbContext.Genres
            .Where(g => g.ParentGenreId == parentGenreId)
            .ToListAsync();
    }

    public Task RemoveAsync(Genre genre)
    {
        _dbContext.Remove(genre);
        return Task.CompletedTask;
    }

    public async Task<bool> HasChildGenresAsync(Guid parentGenreId)
    {
        return await _dbContext.Genres.AnyAsync(g => g.ParentGenreId == parentGenreId);
    }
}
