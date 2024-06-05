using ErrorOr;

using GameStore.Application.Common.Interfaces;

using MediatR;

namespace GameStore.Application.Games.Queries;

public class GetGameFileBytesByKeyQueryHandler(
    IGameRepository gameRepository,
    IGameFileRepository gameFileRepository)
    : IRequestHandler<GetGameFileBytesByKeyQuery, ErrorOr<byte[]>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IGameFileRepository _gameFileRepository = gameFileRepository;

    public async Task<ErrorOr<byte[]>> Handle(GetGameFileBytesByKeyQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetByKeyAsync(request.GameKey);
        return game == null
            ? Error.Validation(description: "Game with provided key not found")
            : await _gameFileRepository.GetLastGameFileBytesAsync(game.Name);
    }
}
