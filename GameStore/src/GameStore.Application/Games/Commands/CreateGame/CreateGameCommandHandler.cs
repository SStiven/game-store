using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Commands.CreateGame;

public class CreateGameCommandHandler(
    IGenreRepository genreRepository,
    IGameRepository gameRepository,
    IPlatformRepository platformRepository,
    IGameFileRepository gameFileRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateGameCommand, ErrorOr<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IGenreRepository _genreRepository = genreRepository;
    private readonly IPlatformRepository _platformRepository = platformRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IGameFileRepository _gameFileRepository = gameFileRepository;

    public async Task<ErrorOr<Game>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var areAllGenreIdsPresent = await _genreRepository.AreAllPresentAsync(request.GenreIds);
        if (!areAllGenreIdsPresent)
        {
            return Error.Validation(description: "Some genre ids doesn't exist");
        }

        var areAllPlatformIdsPresent = await _platformRepository.AreAllPresentAsync(request.PlatformIds);
        if (!areAllPlatformIdsPresent)
        {
            return Error.Validation(description: "Some platform ids doesn't exist");
        }

        var game = new Game(request.Name, request.Key, request.Description, request.GenreIds, request.PlatformIds);

        await _gameFileRepository.SaveGameFileAsync(game);

        await _gameRepository.AddAsync(game);
        await _unitOfWork.SaveChangesAsync();

        return game;
    }
}
