using ErrorOr;
using MediatR;

namespace GameStore.Application.Games.Queries;
public record GetGameFileBytesByKeyQuery(string GameKey) : IRequest<ErrorOr<byte[]>>;
