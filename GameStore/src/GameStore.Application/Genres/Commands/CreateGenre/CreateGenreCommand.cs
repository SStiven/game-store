using ErrorOr;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Commands.CreateGenre;

public record CreateGenreCommand(string Name, Guid? ParentGenreId) : IRequest<ErrorOr<Genre>>;