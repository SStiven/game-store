using ErrorOr;

using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Carts.Queries;

public record GetCartQuery : IRequest<ErrorOr<IReadOnlyList<OrderGame>>>;