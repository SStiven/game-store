using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Orders.Queries;
public class ListOrderHistoryQueryHandler : IRequestHandler<ListOrderHistoryQuery, IReadOnlyList<Order>>
{
    private readonly IReadOnlyOrderRepository _readOnlyOrderRepository;
    private readonly IOrderRepository _orderRepository;

    public ListOrderHistoryQueryHandler(IReadOnlyOrderRepository readOnlyOrderRepository, IOrderRepository orderRepository)
    {
        ArgumentNullException.ThrowIfNull(readOnlyOrderRepository);
        ArgumentNullException.ThrowIfNull(orderRepository);

        _readOnlyOrderRepository = readOnlyOrderRepository;
        _orderRepository = orderRepository;
    }

    public async Task<IReadOnlyList<Order>> Handle(ListOrderHistoryQuery request, CancellationToken cancellationToken)
    {
        var ordersFromSqlServer = await _orderRepository.GetAllPaidOrCancelledAsync();
        var ordersFromMongoDb = await _readOnlyOrderRepository.GetAllAsync();

        var allOrders = ordersFromSqlServer.Concat(ordersFromMongoDb);
        return allOrders.ToList();
    }
}
