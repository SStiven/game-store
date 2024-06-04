using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public class ListAllGamesQueryHandler(IGameRepository gameRepository) : IRequestHandler<ListAllGamesQuery, IReadOnlyList<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<IReadOnlyList<Game>> Handle(ListAllGamesQuery request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetAllAsync();
    }
}