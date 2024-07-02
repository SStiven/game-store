using ErrorOr;

using GameStore.Domain.Orders;

using MediatR;

namespace GameStore.Application.Orders.Queries;

public record GetOrderDetailsByIdQuery(Guid OrderId) : IRequest<ErrorOr<IReadOnlyList<OrderGame>>>;
