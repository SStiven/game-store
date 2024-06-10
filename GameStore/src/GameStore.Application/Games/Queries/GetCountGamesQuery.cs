using MediatR;

namespace GameStore.Application.Games.Queries;

public record GetCountGamesQuery : IRequest<int>;
