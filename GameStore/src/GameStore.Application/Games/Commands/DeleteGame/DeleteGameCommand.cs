using ErrorOr;
using MediatR;

namespace GameStore.Application.Games.Commands.DeleteGame;

public record DeleteGameCommand(Guid Id) : IRequest<ErrorOr<Deleted>>;