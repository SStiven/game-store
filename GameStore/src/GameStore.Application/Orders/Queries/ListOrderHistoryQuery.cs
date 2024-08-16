using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Orders.Queries;

public record ListOrderHistoryQuery : IRequest<IReadOnlyList<Order>>;
