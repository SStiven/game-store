using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Queries;

public class ListGamesWithPlatformIdQueryHandler(IGameRepository gameRepository)
    : IRequestHandler<ListGamesWithPlatformIdQuery, ErrorOr<IReadOnlyList<Game>>>
{
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<ErrorOr<IReadOnlyList<Game>>> Handle(ListGamesWithPlatformIdQuery request, CancellationToken cancellationToken)
    {
        return await _gameRepository.GetByPlatformIdAsync(request.PlatformId);
    }
}