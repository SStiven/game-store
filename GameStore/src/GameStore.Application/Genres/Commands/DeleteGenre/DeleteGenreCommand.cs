using ErrorOr;
using MediatR;

namespace GameStore.Application.Genres.Commands.DeleteGenre;

public record DeleteGenreCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;