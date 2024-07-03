using ErrorOr;

using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Payments;

using MediatR;

namespace GameStore.Application.Orders.Command.PayCartWirhIBoxTerminal;
internal class PayCartWithIBoxTerminalCommandHandler(
    IOrderRepository orderRepository,
    IPaymentClient paymentClient) : IRequestHandler<PayCartWithIBoxTerminalCommand, ErrorOr<IBoxTerminalPayment>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IPaymentClient _paymentClient = paymentClient;

    public async Task<ErrorOr<IBoxTerminalPayment>> Handle(
        PayCartWithIBoxTerminalCommand request,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetFirstOpenOrderAsync();
        if (order is null)
        {
            return Error.NotFound();
        }

        var result = await _paymentClient.MakeIBoxTerminalPaymentAsync();
        if (!result.IsError)
        {
            order.Pay();
            await _orderRepository.UpdateAsync(order);
            var paymentInfo = new IBoxTerminalPayment(Guid.NewGuid(), order.Id, result.Value, order.GetTotal());
            return paymentInfo;
        }

        return result.FirstError;
    }
}
