using GameStore.Domain.Orders;

namespace GameStore.Application.Common.Interfaces;
public interface IOrderRepository
{
    Task<Order> AddAsync(Order order);

    Task<Order> UpdateAsync(Order order);

    Task<Order?> GetFirstOpenOrderAsync();

    Task<Order?> GetOpenOrderByGameIdAsync(Guid gameId);

    Task DeleteAsync(Order order);

    Task<IReadOnlyList<Order>> GetAllPaidOrCancelledAsync();

    Task<Order?> GetOrderByIdAsync(Guid id);
}
