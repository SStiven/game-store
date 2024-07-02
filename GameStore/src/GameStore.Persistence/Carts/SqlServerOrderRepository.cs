using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Orders;

using Microsoft.EntityFrameworkCore;

using SmartShop.Infrastructure.Persistance.Common.EntityFrameworkCore;

namespace GameStore.Persistence.Carts;
public class SqlServerOrderRepository(GameStoreSqlServerDbContext context) : IOrderRepository
{
    private readonly GameStoreSqlServerDbContext _context = context;

    public async Task<Order> AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        return order;
    }

    public Task DeleteAsync(Order order)
    {
        _context.Remove(order);
        return Task.CompletedTask;
    }

    public async Task<IReadOnlyList<Order>> GetAllPaidOrCancelledAsync()
    {
        return await _context
            .Orders
            .Where(o => o.Status == OrderStatus.Paid || o.Status == OrderStatus.Cancelled)
            .ToListAsync();
    }

    public async Task<Order?> GetCart()
    {
        return await _context.Orders
            .Include(o => o.OrderGames)
            .FirstOrDefaultAsync(o => o.Status == OrderStatus.Open);
    }

    public async Task<Order?> GetFirstOpenOrderAsync()
    {
        return await _context.Orders
            .Include(o => o.OrderGames)
            .FirstOrDefaultAsync(o => o.Status == OrderStatus.Open);
    }

    public async Task<Order?> GetOpenOrderByGameIdAsync(Guid gameId)
    {
        return await _context.Orders
            .Include(o => o.OrderGames)
            .FirstOrDefaultAsync(
                o =>
                    o.Status == OrderStatus.Open
                    && o.OrderGames.Any(og => og.ProductId == gameId));
    }

    public async Task<Order?> GetOrderByIdAsync(Guid id)
    {
        return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Order?> GetOrderIncludingOrderGamesByOrderIdAsync(Guid orderId)
    {
        return await _context.Orders
            .Include(o => o.OrderGames)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public Task<Order> UpdateAsync(Order order)
    {
        _context.Orders.Update(order);
        return Task.FromResult(order);
    }
}
