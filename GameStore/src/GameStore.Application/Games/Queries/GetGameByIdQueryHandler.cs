using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public class GetGameByIdQueryHandler(IGameRepository gameRepository) : IRequestHandler<GetGameByIdQuery, ErrorOr<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<ErrorOr<Game>> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByIdAsync(request.Id);
        return game is null ? Error.NotFound("Game not found") : game;
    }
}