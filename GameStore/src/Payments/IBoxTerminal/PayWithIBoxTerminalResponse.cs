namespace Payments.IBoxTerminal;

public record PayWithIBoxTerminalResponse(Guid UserId, double Amount, DateTimeOffset PaymentDate);
