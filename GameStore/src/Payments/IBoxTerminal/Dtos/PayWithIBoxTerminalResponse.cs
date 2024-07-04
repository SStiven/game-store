namespace Payments.IBoxTerminal.Dtos;

public record PayWithIBoxTerminalResponse(Guid UserId, double Amount, DateTimeOffset PaymentDate);
