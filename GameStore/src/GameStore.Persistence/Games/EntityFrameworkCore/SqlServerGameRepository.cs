using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using Microsoft.EntityFrameworkCore;
using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence.Games.EntityFrameworkCore;

public class SqlServerGameRepository(GameStoreSqlServerDbContext dbContext) : IGameRepository
{
    private readonly GameStoreSqlServerDbContext _dbContext = dbContext;

    public async Task AddAsync(Game game)
    {
        await _dbContext.Games.AddAsync(game);
    }

    public async Task<Game?> GetByKeyAsync(string key)
    {
        return await _dbContext.Games.FirstOrDefaultAsync(g => g.Key == key);
    }

    public async Task<Game?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Games.FindAsync(id);
    }

    public async Task<List<Game>> GetByPlatformIdAsync(Guid platformId)
    {
        return await _dbContext.Games.Where(g => g.GamePlatforms.Any(gp => gp.PlatformId == platformId))
            .Include(g => g.GamePlatforms)
            .ToListAsync();
    }

    public async Task<List<Game>> GetByGenreIdAsync(Guid genreId)
    {
        return await _dbContext.Games.Where(g => g.GameGenres.Any(gg => gg.GenreId == genreId))
            .Include(g => g.GameGenres)
            .ToListAsync();
    }

    public Task Update(Game game)
    {
        _dbContext.Games.Update(game);
        return Task.CompletedTask;
    }

    public async Task<Game?> GetByIdWithGenresAndPlatformsAsync(Guid id)
    {
        return await _dbContext.Games
            .Include(g => g.GameGenres)
            .Include(g => g.GamePlatforms)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    public Task RemoveAsync(Game game)
    {
        _dbContext.Games.Remove(game);
        return Task.CompletedTask;
    }

    public async Task<IReadOnlyList<Game>> GetAllAsync()
    {
        return await _dbContext.Games.ToListAsync();
    }

    public async Task<bool> HasGamesWithPlatformIdAsync(Guid platformId)
    {
        return await _dbContext
            .Games
            .AnyAsync(g => g.GamePlatforms.Any(gp => gp.PlatformId == platformId));
    }
}
