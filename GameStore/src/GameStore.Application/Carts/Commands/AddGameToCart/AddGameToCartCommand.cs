using ErrorOr;

using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Carts.Commands.AddGameToCart;

public record AddGameToCartCommand(Guid CostumerId, string GameKey) : IRequest<ErrorOr<Order>>;
