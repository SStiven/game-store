using ErrorOr;

using GameStore.Domain.Payments;

using MediatR;

namespace GameStore.Application.Orders.Command.PayCartWirhIBoxTerminal;

public record PayCartWithIBoxTerminalCommand() : IRequest<ErrorOr<IBoxTerminalPayment>>;