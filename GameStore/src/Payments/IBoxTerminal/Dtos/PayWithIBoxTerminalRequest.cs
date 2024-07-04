namespace Payments.IBoxTerminal.Dtos;

public record PayWithIBoxTerminalRequest(Guid UserId, double Amount);
