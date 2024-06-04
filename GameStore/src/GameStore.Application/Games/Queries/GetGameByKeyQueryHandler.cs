using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public class GetGameByKeyQueryHandler(IGameRepository gameRepository) : IRequestHandler<GetGameByKeyQuery, ErrorOr<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<ErrorOr<Game>> Handle(GetGameByKeyQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.Key);
        return game is null ? (ErrorOr<Game>)Error.NotFound("Game not found") : (ErrorOr<Game>)game;
    }
}
