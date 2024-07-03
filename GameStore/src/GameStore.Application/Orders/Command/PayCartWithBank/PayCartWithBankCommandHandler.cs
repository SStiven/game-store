using ErrorOr;

using GameStore.Application.Common.Interfaces;

using MediatR;

namespace GameStore.Application.Orders.Command.PayCartWithBank;

public class PayCartWithBankCommandHandler(
    IOrderRepository orderRepository,
    IPdfGeneratorService pdfGeneratorService)
    : IRequestHandler<PayCartWithBankCommand, ErrorOr<byte[]>>
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IPdfGeneratorService _pdfGeneratorService = pdfGeneratorService;

    public async Task<ErrorOr<byte[]>> Handle(PayCartWithBankCommand request, CancellationToken cancellationToken)
    {
        var openOrder = await _orderRepository.GetFirstOpenOrderAsync();
        return openOrder is null
            ? Error.Validation(description: "No open order found")
            : _pdfGeneratorService.GenerateInvoicePdf(openOrder);
    }
}
