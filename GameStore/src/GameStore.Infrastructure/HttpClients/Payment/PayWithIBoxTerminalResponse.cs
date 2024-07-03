namespace GameStore.Infrastructure.HttpClients.Payment;

public record PayWithIBoxTerminalResponse(Guid UserId, DateTimeOffset PaymentDate);
