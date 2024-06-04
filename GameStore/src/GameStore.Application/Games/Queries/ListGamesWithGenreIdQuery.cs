using ErrorOr;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public record ListGamesWithGenreIdQuery(Guid GenreId) : IRequest<ErrorOr<IList<Game>>>;
