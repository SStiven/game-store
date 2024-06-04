using ErrorOr;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public record GetGameByKeyQuery(string Key) : IRequest<ErrorOr<Game>>;
