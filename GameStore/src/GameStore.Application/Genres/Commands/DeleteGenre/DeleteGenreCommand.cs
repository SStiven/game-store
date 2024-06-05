using ErrorOr;
using MediatR;

namespace GameStore.Application.Genres.Commands.DeleteGame;

public record DeleteGenreCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;