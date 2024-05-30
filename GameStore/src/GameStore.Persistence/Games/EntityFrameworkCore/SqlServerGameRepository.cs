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

    public async Task<IReadOnlyList<Game>> GetAllAsync()
    {
        return await _dbContext.Games.ToListAsync();
    }
}
