using GameStore.Application.Common.Interfaces;
using GameStore.Domain.Games;

using MediatR;

namespace GameStore.Application.Games.Queries;

public class ListAllGamesQueryHandler(
    IGameRepository gameRepository,
    IReadOnlyGameRespository readOnlyGameRespository)
    : IRequestHandler<ListAllGamesQuery, IReadOnlyList<Game>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IReadOnlyGameRespository _readOnlyGameRespository = readOnlyGameRespository;

    public async Task<IReadOnlyList<Game>> Handle(
        ListAllGamesQuery request,
        CancellationToken cancellationToken)
    {
        var gamesFromSQLServer = await _gameRepository.GetAllAsync();
        var gamesFromMongoDB = await _readOnlyGameRespository.GetAllAsync();

        var gameDictionary = new Dictionary<string, Game>();

        foreach (var game in gamesFromSQLServer)
        {
            if (!string.IsNullOrEmpty(game.Key))
            {
                gameDictionary[game.Key] = game;
            }
        }

        foreach (var game in gamesFromMongoDB)
        {
            if (!string.IsNullOrEmpty(game.Key))
            {
                if (gameDictionary.TryGetValue(game.Key, out var existingGame))
                {
                    existingGame.UnitInStock += game.UnitInStock;
                }
                else
                {
                    gameDictionary[game.Key] = game;
                }
            }
        }

        var games = gameDictionary.Values.ToList();

        return games;
    }
}