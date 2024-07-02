using ErrorOr;
using MediatR;

namespace GameStore.Application.Carts.Commands.RemoveGameFromCart;

public record DeleteGameFromCartCommand(Guid CustomerId, string GameKey)
    : IRequest<ErrorOr<Deleted>>;
