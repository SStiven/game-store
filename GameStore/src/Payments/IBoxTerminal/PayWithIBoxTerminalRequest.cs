namespace Payments.IBoxTerminal;

public record PayWithIBoxTerminalRequest(Guid UserId, double Amount);
