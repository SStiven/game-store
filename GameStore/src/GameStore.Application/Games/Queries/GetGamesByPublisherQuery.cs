using GameStore.Domain.Games;

using MediatR;

namespace GameStore.Application.Games.Queries;

public record GetGamesByPublisherQuery(string CompanyName)
    : IRequest<IReadOnlyList<Game>>;