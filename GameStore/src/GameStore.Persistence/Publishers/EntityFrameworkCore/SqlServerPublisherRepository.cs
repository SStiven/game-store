using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Publishers;

using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence.Publishers.EntityFrameworkCore;
public class SqlServerPublisherRepository(GameStoreSqlServerDbContext context) : IPublisherRepository
{
    private readonly GameStoreSqlServerDbContext _context = context;

    public async Task<Publisher?> GetByIdAsync(Guid id)
    {
        return await _context.Publishers.FindAsync(id);
    }
}
