using ErrorOr;

using GameStore.Application.Common.Interfaces;

using MediatR;

namespace GameStore.Application.Carts.Commands.RemoveGameFromCart;

public class DeleteGameFromCartCommandHandler(
    IGameRepository gameRepository,
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteGameFromCartCommand, ErrorOr<Deleted>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Deleted>> Handle(DeleteGameFromCartCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.GameKey);
        if (game is null)
        {
            return Error.NotFound("Game not found");
        }

        var order = await _orderRepository.GetOpenOrderByGameIdAsync(game.Id);
        if (order is null)
        {
            return Error.NotFound("There isn't an open order with that game key.");
        }

        order.RemoveGame(game.Id);
        if (order.IsEmpty())
        {
            await _orderRepository.DeleteAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return Result.Deleted;
        }

        await _orderRepository.UpdateAsync(order);
        await _unitOfWork.SaveChangesAsync();
        return Result.Deleted;
    }
}
