using ErrorOr;

using GameStore.Domain.Publishers;

using MediatR;

namespace GameStore.Application.Publishers.Queries;
public record GetPublisherByGameKeyQuery(string GameKey) : IRequest<ErrorOr<Publisher>>;
