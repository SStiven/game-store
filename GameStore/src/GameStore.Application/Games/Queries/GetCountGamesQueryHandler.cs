using GameStore.Application.Common.Interfaces;
using MediatR;

namespace GameStore.Application.Games.Queries;
public class GetCountGamesQueryHandler(IGameRepository gameRepository) : IRequestHandler<GetCountGamesQuery, int>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<int> Handle(GetCountGamesQuery request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetCountAsync();
    }
}
