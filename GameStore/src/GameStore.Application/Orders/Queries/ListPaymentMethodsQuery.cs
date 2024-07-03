using GameStore.Domain.Payments;

using MediatR;

namespace GameStore.Application.Orders.Queries;

public record ListPaymentMethodsQuery() : IRequest<IEnumerable<PaymentMethod>>;
