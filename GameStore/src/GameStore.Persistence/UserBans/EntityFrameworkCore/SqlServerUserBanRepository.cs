using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Bans;

using Microsoft.EntityFrameworkCore;

using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence.UserBans.EntityFrameworkCore;
public class SqlServerUserBanRepository(GameStoreSqlServerDbContext context) : IUserBanRepository
{
    private readonly GameStoreSqlServerDbContext _context = context;

    public async Task AddAsync(UserBan userBan)
    {
        await _context.UserBans.AddAsync(userBan);
    }

    public async Task<UserBan?> GetByUserNameAsync(string userName)
    {
        return await _context
            .UserBans
            .FirstOrDefaultAsync(b => b.UserName == userName);
    }

    public Task UpdateAsync(UserBan userBan)
    {
        _context.UserBans.Update(userBan);
        return Task.CompletedTask;
    }
}
