using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Queries;

public record ListAllGenresQuery() : IRequest<IReadOnlyList<Genre>>;