using ErrorOr;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Queries;

public record ListGenresByParentGenreIdQuery(Guid ParentGenreId) : IRequest<ErrorOr<IReadOnlyList<Genre>>>;