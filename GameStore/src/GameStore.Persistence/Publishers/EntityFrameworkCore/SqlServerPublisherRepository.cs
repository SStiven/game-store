using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Publishers;

using Microsoft.EntityFrameworkCore;

using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence.Publishers.EntityFrameworkCore;
public class SqlServerPublisherRepository(GameStoreSqlServerDbContext context) : IPublisherRepository
{
    private readonly GameStoreSqlServerDbContext _context = context;

    public async Task<bool> AnyWithCompanyNameAsync(string companyName)
    {
        return await _context.Publishers.AnyAsync(p => p.CompanyName == companyName);
    }

    public async Task<Publisher?> GetByIdAsync(Guid id)
    {
        return await _context.Publishers.FindAsync(id);
    }

    public async Task AddAsync(Publisher publisher)
    {
        await _context.Publishers.AddAsync(publisher);
    }

    public Task DeleteAsync(Publisher publisher)
    {
        _context.Publishers.Remove(publisher);
        return Task.CompletedTask;
    }
}
