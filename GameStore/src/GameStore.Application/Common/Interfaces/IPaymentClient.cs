using ErrorOr;

namespace GameStore.Application.Common.Interfaces;
public interface IPaymentClient
{
    Task<ErrorOr<DateTimeOffset>> MakeIBoxTerminalPaymentAsync(Guid userId, double amount);
}
