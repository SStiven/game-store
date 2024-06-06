using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Platforms;
using MediatR;

namespace GameStore.Application.Platforms.Queries;

public class ListPlatformsByGameKeyQueryHandler(
    IPlatformRepository platformRepository,
    IGameRepository gameRepository)
    : IRequestHandler<ListPlatformsByGameKeyQuery, ErrorOr<IReadOnlyList<Platform>>>
{
    private readonly IPlatformRepository _platformRepository = platformRepository;
    private readonly IGameRepository _gameRepository = gameRepository;

    public async Task<ErrorOr<IReadOnlyList<Platform>>> Handle(ListPlatformsByGameKeyQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.GameKey);
        return game is null
            ? Error.Validation(description: "Game not found")
            : await _platformRepository.GetByGameIdAsync(game.Id);
    }
}