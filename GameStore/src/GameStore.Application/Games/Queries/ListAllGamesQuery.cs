using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public record ListAllGamesQuery : IRequest<IReadOnlyList<Game>>;