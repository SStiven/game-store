namespace GameStore.Infrastructure.HttpClients.Payment;

public record PayWithIBoxTerminalRequest(Guid UserId, double Amount);
