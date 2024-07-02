using ErrorOr;

using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Orders.Queries;

public record GetOrderByIdQuery(Guid Id) : IRequest<ErrorOr<Order>>;