using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Orders.Queries;
public class ListAllPaidOrCancelledOrdersQueryHandler(
    IOrderRepository orderRepository) : IRequestHandler<ListAllPaidOrCancelledOrders, IReadOnlyList<Order>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<IReadOnlyList<Order>> Handle(ListAllPaidOrCancelledOrders request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetAllPaidOrCancelledAsync();
    }
}
