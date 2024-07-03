using GameStore.Domain.Payments;

using MediatR;

namespace GameStore.Application.Orders.Queries;

public class ListPaymentMethodsQueryHandler : IRequestHandler<ListPaymentMethodsQuery, IEnumerable<PaymentMethod>>
{
    public Task<IEnumerable<PaymentMethod>> Handle(ListPaymentMethodsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult<IEnumerable<PaymentMethod>>(
        [
            PaymentMethod.Bank,
            PaymentMethod.Visa,
            PaymentMethod.IBoxTerminal,
        ]);
    }
}
