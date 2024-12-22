using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Publishers;
using GameStore.Persistence.Common.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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

    public async Task<Publisher?> GetByCompanyNameAsync(string companyName)
    {
        return await _context
            .Publishers
            .FirstOrDefaultAsync(p => p.CompanyName == companyName);
    }

    public async Task<ErrorOr<IReadOnlyList<Publisher>>> GetAllAsync()
    {
        return await _context.Publishers.ToListAsync();
    }

    public async Task<Publisher?> GetByGameKeyAsync(string gameKey)
    {
        return await _context.Publishers
            .FirstOrDefaultAsync(p => p.Games.Any(g => g.Key == gameKey));
    }

    public Task Update(Publisher existingPublisher)
    {
        _context.Publishers.Update(existingPublisher);
        return Task.CompletedTask;
    }
}
