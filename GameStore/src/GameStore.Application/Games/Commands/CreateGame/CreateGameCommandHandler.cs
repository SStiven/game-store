using ErrorOr;
using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;
using MediatR;

namespace GameStore.Application.Games.Commands.CreateGame;

public class CreateGameCommandHandler(IGameRepository gameRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateGameCommand, ErrorOr<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<ErrorOr<Game>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        var newGameId = Guid.NewGuid();
        var game = new Game
        {
            Id = newGameId,
            Name = request.Name,
            Key = request.Key,
            Description = request.Description,
            GamePlatforms = request.PlatformIds.Select(p => new GamePlatform { PlatformId = p, GameId = newGameId }).ToList(),
            GameGenres = request.GenreIds.Select(g => new GameGenre { GenreId = g, GameId = newGameId }).ToList(),
        };

        await _gameRepository.AddAsync(game);
        await _unitOfWork.SaveChangesAsync();

        return game;
    }
}
