using ErrorOr;

using GameStore.Domain.Payments;

namespace GameStore.Application.Common.Interfaces;
public interface IPaymentClient
{
    Task<ErrorOr<DateTimeOffset>> MakeIBoxTerminalPaymentAsync(Guid userId, double amount);

    Task<ErrorOr<Success>> MakeVisaPaymentAsync(VisaCard visaCard, double amount);
}
