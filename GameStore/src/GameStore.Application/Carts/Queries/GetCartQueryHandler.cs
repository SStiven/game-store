using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Carts.Queries;
internal class GetCartQueryHandler(
    IOrderRepository orderRepository)
    : IRequestHandler<GetCartQuery, ErrorOr<IReadOnlyList<OrderGame>>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;

    public async Task<ErrorOr<IReadOnlyList<OrderGame>>> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _orderRepository.GetCart();
        return cart is null
            ? Error.NotFound(description: "Cart not found")
            : cart.OrderGames.ToList();
    }
}
