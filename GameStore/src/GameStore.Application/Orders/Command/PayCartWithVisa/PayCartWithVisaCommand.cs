using ErrorOr;

using MediatR;

namespace GameStore.Application.Orders.Command.PayCartWithVisa;

public record PayCartWithVisaCommand(
    string Holder,
    string CardNumber,
    int MonthExpire,
    int YearExpire,
    int Cvv2) : IRequest<ErrorOr<Success>>;