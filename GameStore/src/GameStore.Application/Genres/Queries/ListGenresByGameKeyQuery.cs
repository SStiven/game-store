using ErrorOr;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Queries;

public record ListGenresByGameKeyQuery(string GameKey) : IRequest<ErrorOr<IReadOnlyList<Genre>>>;