using GameStore.Domain.Orders;

namespace GameStore.Application.Common.Interfaces;

public interface IPdfGeneratorService
{
    byte[] GenerateInvoicePdf(Order order);
}
