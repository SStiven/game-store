using GameStore.Domain.Orders;

namespace GameStore.Application.Common.Interfaces;

public interface IReadOnlyOrderRepository
{
    Task<IReadOnlyList<Order>> GetAllAsync();
}
