using ErrorOr;

using GameStore.Domain.Bans;

using MediatR;

namespace GameStore.Application.Users.Commands.BanUser;

public record BanUserCommand(string UserName, BanDuration BanDuration)
    : IRequest<ErrorOr<Success>>;