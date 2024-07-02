using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Orders.Queries;

public class GetOrderDetailsByIdQueryHandler(IOrderRepository orderRepository)
    : IRequestHandler<GetOrderDetailsByIdQuery, ErrorOr<IReadOnlyList<OrderGame>>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<ErrorOr<IReadOnlyList<OrderGame>>> Handle(GetOrderDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderIncludingOrderGamesByOrderIdAsync(request.OrderId);

        return order is null
            ? Error.NotFound(description: $"Order with id {request.OrderId} not found")
            : order.OrderGames.ToList();
    }
}
