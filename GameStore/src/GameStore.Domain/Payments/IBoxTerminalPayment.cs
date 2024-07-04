namespace GameStore.Domain.Payments;

public class IBoxTerminalPayment(Guid userId, Guid orderId, DateTimeOffset paymentDate, double sum)
{
    public Guid UserId { get; } = userId;

    public Guid OrderId { get; } = orderId;

    public DateTimeOffset PaymentDate { get; } = paymentDate;

    public double Sum { get; } = sum;
}
