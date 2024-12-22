using ErrorOr;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Games.Queries;

public record ListGamesByGenreIdQuery(Guid GenreId) : IRequest<ErrorOr<IReadOnlyList<Genre>>>;