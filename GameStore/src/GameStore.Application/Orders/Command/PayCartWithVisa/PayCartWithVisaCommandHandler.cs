using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Payments;

using MediatR;

namespace GameStore.Application.Orders.Command.PayCartWithVisa;

public class PayCartWithVisaCommandHandler(
    IPaymentClient paymentClient,
    IOrderRepository orderRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<PayCartWithVisaCommand, ErrorOr<Success>>
{
    private readonly IPaymentClient _paymentClient = paymentClient;
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Success>> Handle(PayCartWithVisaCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetFirstOpenOrderAsync();
        if (order is null)
        {
            return Error.NotFound();
        }

        var visaCard = new VisaCard(
            request.Holder,
            request.CardNumber,
            request.MonthExpire,
            request.YearExpire,
            request.Cvv2);

        var result = await _paymentClient.MakeVisaPaymentAsync(visaCard, order.GetTotal());
        if (!result.IsError)
        {
            order.Pay();
            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success;
        }

        return result.Errors;
    }
}
