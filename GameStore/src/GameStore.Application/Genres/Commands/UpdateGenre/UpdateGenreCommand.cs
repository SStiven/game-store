using ErrorOr;
using GameStore.Domain.Genres;
using MediatR;

namespace GameStore.Application.Genres.Commands.UpdateGenre;

public record UpdateGenreCommand(
    Guid Id,
    string Name,
    Guid? ParentGenreId) : IRequest<ErrorOr<Genre>>;