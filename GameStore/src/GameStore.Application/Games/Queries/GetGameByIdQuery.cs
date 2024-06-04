using ErrorOr;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public record GetGameByIdQuery(Guid Id) : IRequest<ErrorOr<Game>>;