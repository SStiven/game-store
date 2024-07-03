using ErrorOr;
using MediatR;

namespace GameStore.Application.Orders.Command.PayCartWithBank;

public record PayCartWithBankCommand() : IRequest<ErrorOr<byte[]>>;
