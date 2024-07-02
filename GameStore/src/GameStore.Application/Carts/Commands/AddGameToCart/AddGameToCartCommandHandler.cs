using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Carts.Commands.AddGameToCart;

public class AddGameToCartCommandHandler(
    IGameRepository gameRepository,
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork,
    ISystemClock systemClock)
    : IRequestHandler<AddGameToCartCommand, ErrorOr<Order>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ISystemClock _systemClock = systemClock;

    public async Task<ErrorOr<Order>> Handle(AddGameToCartCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.GameKey);
        if (game is null)
        {
            return Error.NotFound(description: "Game not found");
        }

        var order = await _orderRepository.GetFirstOpenOrderAsync();
        if (order is null)
        {
            return game.UnitInStock < 1
                ? Error.Validation(description: "Not enough units in stock")
                : await CreateNewOrder(request.CostumerId, game.Id, game.Price, game.Discount);
        }

        var existingGameOrder = order.OrderGames.FirstOrDefault(og => og.ProductId == game.Id);
        if (existingGameOrder is not null)
        {
            if (existingGameOrder.Quantity + 1 > game.UnitInStock)
            {
                return Error.Validation(description: "Not enough units in stock");
            }

            existingGameOrder.IncreateQuantity();
            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return order;
        }

        var newGameOrder = new OrderGame(order.Id, game.Id, game.Price, 1, null);
        order.AddOrderGame(newGameOrder);

        await _orderRepository.UpdateAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return order;
    }

    private async Task<ErrorOr<Order>> CreateNewOrder(Guid costumerId, Guid gameId, double price, int? discount)
    {
        var orderId = Guid.NewGuid();
        var orderGames = new List<OrderGame>
            {
                new(orderId, gameId, price, 1, discount),
            };

        var newOrder = new Order(orderId, costumerId, _systemClock.UtcNow.DateTime, orderGames);
        await _orderRepository.AddAsync(newOrder);
        await _unitOfWork.SaveChangesAsync();
        return newOrder;
    }
}
